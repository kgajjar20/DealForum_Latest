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
    public class AdminForumApiController : ControllerBase
    {


        IAdminForum _adminForumRepository;
        IConfiguration _configuration;
        IException _exception;
        IActionTracking _actionTracking;

        public AdminForumApiController(IAdminForum adminForumRepository, IConfiguration configuration, IException exception, IActionTracking tracking)
        {
            _adminForumRepository = adminForumRepository;
            _configuration = configuration;
            _exception = exception;
            _actionTracking = tracking;
        }

        [HttpPost]
        [Route("ForumsListGet")]
        public async Task<IActionResult> ForumsListGet([FromBody] ForumModel model)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    DataTableResponse dtResponse = await _adminForumRepository.GetForumsList(model);
                    if (string.IsNullOrWhiteSpace(dtResponse.error))
                    {
                        response = new APIResponseModel
                        {
                            Status = true,
                            Code = (int)ResponseCode.OK,
                            Data = JsonConvert.SerializeObject(dtResponse, Formatting.Indented),
                        };
                        await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.View, $"GetForumsList Action Tracking Data");
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

        [HttpGet]
        [Route("ForumsListGet")]
        public async Task<IActionResult> GetForumsList()
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    List<ForumDetail> forumsList = await _adminForumRepository.GetForumsList();
                    response = new APIResponseModel
                    {
                        Status = true,
                        Code = (int)ResponseCode.OK,
                        Data = JsonConvert.SerializeObject(forumsList, Formatting.Indented),
                    };
                    await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.View, $"GetForumsList Action Tracking Data");
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
                    Code = (int)EnumHelper.ResponseCode.InternalServerError,
                    Message = SharedResource.Error
                };
                await _exception.SaveExceptionTracking(Convert.ToString(ex));
                return BadRequest(response);
            }
        }


        [HttpPost]
        [Route("ForumGet")]
        public async Task<IActionResult> ForumGet([FromBody] Guid Id)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (Id != Guid.Empty)
                {
                    var claim = ClaimsHelper.GetClaimsDetail((ClaimsIdentity)User.Identity);
                    response = await _adminForumRepository.GetForum(Id, _actionTracking);
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
        public async Task<IActionResult> Post([FromBody] AddEditForumDetail model)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    var claim = ClaimsHelper.GetClaimsDetail((ClaimsIdentity)User.Identity);
                    response = await _adminForumRepository.AddUpdateForum(model, _actionTracking, claim.UserId);
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

        #region Active / Inactive Forum
        [HttpPost]
        [Route("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] ForumStatusModel model)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        var claim = ClaimsHelper.GetClaimsDetail((ClaimsIdentity)User.Identity);
                        response = await _adminForumRepository.ChangeForumStatus(model, _actionTracking, claim.UserId);
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

        #region Delete Forum
        [HttpPost]
        [Route("DeleteForum")]
        public async Task<IActionResult> DeleteForum([FromBody] Guid Id)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                if (Id !=Guid.Empty)
                {
                    var claim = ClaimsHelper.GetClaimsDetail((ClaimsIdentity)User.Identity);
                    response = await _adminForumRepository.DeleteForum(Id, _actionTracking, claim.UserId);
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
