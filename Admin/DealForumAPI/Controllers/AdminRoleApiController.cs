using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DealForumAPI.Common;
using DealForumAPI.Helper;
using DealForumAPI.Interface;
using DealForumAPI.Resources;
using DealForumLibrary;
using DealForumLibrary.Models;
using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static DealForumLibrary.EnumHelper;

namespace DealForumAPI.Controllers
{

    [Route("[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    public class AdminRoleApiController : ControllerBase
    {

        IAdminRole _adminRoleRepository;
        IConfiguration _configuration;
        IException _exception;
        IActionTracking _actionTracking;

        public AdminRoleApiController(IAdminRole adminRoleRepository, IConfiguration configuration, IException exception, IActionTracking tracking)
        {
            _adminRoleRepository = adminRoleRepository;
            _configuration = configuration;
            _exception = exception;
            _actionTracking = tracking;
        }

        [HttpPost]
        [Route("RolesListGet")]
        public async Task<IActionResult> RolesListGet([FromBody] RoleModel model)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    DataTableResponse dtResponse = await _adminRoleRepository.GetRolesList(model);
                    if (string.IsNullOrWhiteSpace(dtResponse.error))
                    {
                        response = new APIResponseModel
                        {
                            Status = true,
                            Code = (int)ResponseCode.OK,
                            Data = JsonConvert.SerializeObject(dtResponse, Formatting.Indented),
                        };
                        await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.View, $"GetRolesList Action Tracking Data");
                        return Ok(response);
                    }
                    else
                    {
                        response = new APIResponseModel
                        {
                            Status = false,
                            Code = (int)ResponseCode.BadRequest,
                            Message = dtResponse.error
                        };
                        return BadRequest(response);
                    }
                }
                else
                {
                    var message = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    response = new APIResponseModel()
                    {
                        Status = false,
                        Code = (int)ResponseCode.BadRequest,
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
                await _exception.SaveExceptionTracking(Convert.ToString(ex));
                return BadRequest(response);
            }
        }


        [HttpPost]
        [Route("RoleGet")]
        public async Task<IActionResult> RoleGet([FromBody] int Id)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (Id > 0)
                {
                    var claim = ClaimsHelper.GetClaimsDetail((ClaimsIdentity)User.Identity);
                    response = await _adminRoleRepository.GetRole(Id, _actionTracking, claim.UserId);
                    return Ok(response);
                }
                else
                {
                    response = new APIResponseModel()
                    {
                        Status = false,
                        Code = (int)ResponseCode.BadRequest,
                        Message = string.Format(SharedResource.NotFound, "Id")
                    };
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response = new APIResponseModel()
                {
                    Status = false,
                    Code = (int)ResponseCode.InternalServerError,
                    Message = SharedResource.Error
                };
                await _exception.SaveExceptionTracking(ex.ToString());
                return BadRequest(response);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEditRoleDetail model)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var claim = ClaimsHelper.GetClaimsDetail((ClaimsIdentity)User.Identity);
                    response = await _adminRoleRepository.AddUpdateRole(model, _actionTracking, claim.UserId);
                    return Ok(response);
                }
                else
                {
                    var message = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    response = new APIResponseModel()
                    {
                        Status = false,
                        Code = (int)ResponseCode.BadRequest,
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
                    Code = (int)ResponseCode.InternalServerError,
                    Message = SharedResource.Error
                };
                await _exception.SaveExceptionTracking(ex.ToString());
                return BadRequest(response);
            }
        }

        #region Active / Inactive Role
        [HttpPost]
        [Route("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] RoleStatusModel model)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        var claim = ClaimsHelper.GetClaimsDetail((ClaimsIdentity)User.Identity);
                        response = await _adminRoleRepository.ChangeRoleStatus(model, _actionTracking, claim.UserId);
                        return Ok(response);
                    }
                }
                var message = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                response = new APIResponseModel()
                {
                    Status = false,
                    Code = (int)ResponseCode.BadRequest,
                    Message = message
                };
                return Unauthorized(response);
            }
            catch (Exception ex)
            {
                response = new APIResponseModel()
                {
                    Status = false,
                    Code = (int)ResponseCode.InternalServerError,
                    Message = SharedResource.Error
                };
                await _exception.SaveExceptionTracking(ex.ToString());
                return BadRequest(response);
            }
        }

        #endregion

        #region Delete Role
        [HttpPost]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRole([FromBody] int Id)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (Id > 0)
                {
                    var claim = ClaimsHelper.GetClaimsDetail((ClaimsIdentity)User.Identity);
                    response = await _adminRoleRepository.DeleteRole(Id, _actionTracking, claim.UserId);
                    return Ok(response);
                }
                else
                {
                    response = new APIResponseModel()
                    {
                        Status = false,
                        Code = (int)ResponseCode.BadRequest,
                        Message = string.Format(SharedResource.NotFound, "Id")
                    };
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response = new APIResponseModel()
                {
                    Status = false,
                    Code = (int)ResponseCode.InternalServerError,
                    Message = SharedResource.Error
                };
                await _exception.SaveExceptionTracking(ex.ToString());
                return BadRequest(response);
            }
        }
        #endregion

    }
}
