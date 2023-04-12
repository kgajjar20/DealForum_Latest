using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealForumAPI.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DealForumLibrary.Models;
using static DealForumLibrary.Common;
using DealForumLibrary.Models.AdminAreaModels;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using DealForumAPI.Common;
using DealForumAPI.SecurityHelper;
using DealForumLibrary;
using Microsoft.Extensions.Configuration;
using DealForumAPI.Resources;
using System.Text;
using static DealForumLibrary.EnumHelper;
using Newtonsoft.Json;

namespace DealForumAPI.Controllers
{
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AdminAuthenticationApiController : ControllerBase
    {
        IAdminLogin _loginRepository;
        IConfiguration _configuration;
        IException _exception;
        IActionTracking _actionTracking;


        public AdminAuthenticationApiController(IAdminLogin loginRepository, IConfiguration configuration, IException exception, IActionTracking tracking)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
            _exception = exception;
            _actionTracking = tracking;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdminLoginModel model)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = await _loginRepository.AdminPortalUserExistAsync(model);
                    if (user != null)
                    {
                        bool validate = await _loginRepository.ValidateAdminPortalLogin(model);
                        if (validate)
                        {
                            var claims = new[]
                            {
                                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                                new Claim(ClaimTypes.Name,user.FullName),
                                new Claim(ClaimTypes.Email, user.Email),
                                new Claim(Common.Common.PortalTypeClaim,Convert.ToString(PortalType.Admin)),
                                new Claim(ClaimTypes.Role,Convert.ToString(user.RoleId)),
                            };

                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
                            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                            var tokenDescriptor = new SecurityTokenDescriptor
                            {
                                Subject = new ClaimsIdentity(claims),
                                Expires = DateTime.Now.AddDays(1),
                                SigningCredentials = creds
                            };

                            var tokenHandler = new JwtSecurityTokenHandler();
                            var token = tokenHandler.CreateToken(tokenDescriptor);
                            user.JWT = tokenHandler.WriteToken(token);
                            response = new APIResponseModel
                            {
                                Status = true,
                                Code = (int)LoginStatus.Success,
                                Data = JsonConvert.SerializeObject(user, Formatting.Indented),
                                Message = SharedResource.LoginSuccess
                            };
                            await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.AdminPortalLogin, $"User logged in : {model.Email}");
                            return Ok(response);
                        }
                        else
                        {
                            response = new APIResponseModel()
                            {
                                Status = false,
                                Code = (int)LoginStatus.Failed,
                                Message = SharedResource.InvalidEmailOrPassword
                            };
                            return Unauthorized(response);
                        }
                    }
                    else
                    {
                        response = new APIResponseModel()
                        {
                            Status = false,
                            Code = (int)LoginStatus.Failed,
                            Message = AdminResource.DoesNotExistForAdminPortalLogin
                        };
                        return Unauthorized(response);
                    }
                }
                else
                {
                    var message = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    response = new APIResponseModel()
                    {
                        Status = false,
                        Code = (int)LoginStatus.Failed,
                        Message = message
                    };
                    return Unauthorized(response);
                }
            }
            catch (Exception ex)
            {
                response = new APIResponseModel()
                {
                    Status = false,
                    Code = (int)EnumHelper.ResponseCode.InternalServerError,
                    Message = SharedResource.Error
                };
                await _exception.SaveExceptionTracking(ex.ToString());
                return BadRequest(response);
            }
        }



    }
}
