using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealForum.Common;
using DealForumLibrary.Models;
using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DealForum.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IOptions<AppSettingsViewModel> _appSettings;
        private static string apiUrl = string.Empty;

        public RoleController(IOptions<AppSettingsViewModel> appSettings, IActionContextAccessor actionContext)
        {
            var routeData = actionContext.ActionContext.RouteData;
            string currentArea = Convert.ToString(routeData.Values["area"] ?? string.Empty);
            string currentController = routeData.Values["controller"].ToString();
            string key = currentArea + currentController;

            Common.Common.ByPassConAct[key] = new List<string> { "" };
            Common.Common.OnlyAuthNoRightsCheck[key] = new List<string> { "Index", "RolesListGet" };
            Common.Common.ViewRightsActions[key] = new List<string> { "" };
            Common.Common.ModifyRightsActions[key] = new List<string> { };

            _appSettings = appSettings;
            apiUrl = _appSettings.Value.APIEndPoint + "AdminRoleApi";
        }

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Get Roles List
        [HttpPost]
        public async Task<JsonResult> GetRolesList(DataTableRequest request)
        {
            RoleModel model = new RoleModel();
            model.Request = request;
            var response = await Common.Common.PostMessageAsync<APIResponseModel>(model, apiUrl + "/RolesListGet", true, UserSession.JWT);

            if (response != null && response.Status == true)
            {
                DataTableResponse dtResponse = JsonConvert.DeserializeObject<DataTableResponse>(response.Data);
                return Json(new
                {
                    draw = dtResponse.draw,
                    recordsTotal = dtResponse.recordsTotal,
                    recordsFiltered = dtResponse.recordsFiltered,
                    data = dtResponse.data,
                    error = response.Message
                });
            }
            return Json(new
            {
                draw = request.Draw,
                error = (response != null && !string.IsNullOrWhiteSpace(response.Message)) ? response.Message : DealForumLibrary.Common.ErrorOccuredMessage
            });
        }

        #endregion
      
        #region Add Role (GET)
        public IActionResult AddRole()
        {
            AddEditRoleDetail model = new AddEditRoleDetail();
            return PartialView("_RequestRole", model);
        }

        #endregion

        #region Add/Update Role
        [HttpPost]
        public async Task<IActionResult> AddUpdateRole(AddEditRoleDetail model)
        {
            var result = false;
            var message = string.Empty;
            if (ModelState.IsValid)
            {
                APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(model, apiUrl, true, UserSession.JWT);
                if (response != null)
                {
                    result = response.Status;
                    message = response.Message;
                }
                else
                {
                    result = false;
                    message = DealForumLibrary.Common.ErrorOccuredMessage;
                }
            }
            else
            {
                result = false;
                message = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            return Json(new
            {
                result = result,
                message = message
            });

        }

        #endregion

        #region Active / Inactive Role
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus([FromBody] RoleStatusModel model)
        {
            var result = false;
            var message = string.Empty;

            APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(model, apiUrl + "/ChangeStatus", true, UserSession.JWT);
            if (response != null)
            {
                result = response.Status;
                message = response.Message;
            }
            else
            {
                result = false;
                message = DealForumLibrary.Common.ErrorOccuredMessage;

            }

            return Json(new
            {
                result = result,
                message = message
            });
        }

        #endregion

        #region Delete Role
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole([FromBody] RoleGetDeleteModel model)
        {
            var result = false;
            var message = string.Empty;

            APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(model.Id, apiUrl + "/DeleteRole", true, UserSession.JWT);
            if (response != null)
            {
                result = response.Status;
                message = response.Message;
            }
            else
            {
                result = false;
                message = DealForumLibrary.Common.ErrorOccuredMessage;
            }

            return Json(new
            {
                result = result,
                message = message
            });
        }

        #endregion

        #region Edit Role
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> EditRole([FromBody] RoleGetDeleteModel role)
        {
            AddEditRoleDetail model = new AddEditRoleDetail();
            if (ModelState.IsValid)
            {
                APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(role.Id, apiUrl + "/RoleGet", true, UserSession.JWT);
                if (response != null)
                {
                    model = JsonConvert.DeserializeObject<AddEditRoleDetail>(response.Data);
                }
                else
                {
                    this.AddNotification(response.Message, NotificationType.ERROR);
                }
            }

            return PartialView("_RequestRole", model);
        }

        #endregion
    }
}
