using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DealForum.Common;
using DealForumLibrary.Models;
using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DealForum.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : Controller
    {
        private readonly IOptions<AppSettingsViewModel> _appSettings;
        private static string apiUrl = string.Empty;
        private readonly IWebHostEnvironment _environment;
        public StoreController(IOptions<AppSettingsViewModel> appSettings, IWebHostEnvironment iHostingEnvironment, IActionContextAccessor actionContext)
        {
            var routeData = actionContext.ActionContext.RouteData;
            string currentArea = Convert.ToString(routeData.Values["area"] ?? string.Empty);
            string currentController = routeData.Values["controller"].ToString();
            string key = currentArea + currentController;

            Common.Common.ByPassConAct[key] = new List<string> { "" };
            Common.Common.OnlyAuthNoRightsCheck[key] = new List<string> { "Index", "AddStore", "GetStoresList", "EditStore" };
            Common.Common.ViewRightsActions[key] = new List<string> { "" };
            Common.Common.ModifyRightsActions[key] = new List<string> { };

            _appSettings = appSettings;
            _environment = iHostingEnvironment;
            apiUrl = _appSettings.Value.APIEndPoint + "AdminStoreApi";
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Get Stores List
        [HttpPost]
        public async Task<JsonResult> GetStoresList(DataTableRequest request)
        {
            StoreModel model = new StoreModel();
            model.Request = request;
            APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(model, apiUrl + "/StoreListGet", true, UserSession.JWT);

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

        #region Add Store (GET)
        [HttpGet]
        public IActionResult AddStore()
        {
            AddEditStoreDetail model = new AddEditStoreDetail();
            return PartialView("_RequestStore", model);
        }
        #endregion

        #region Add/Update Store
        [HttpPost]
        public async Task<IActionResult> AddUpdateStore(IFormFile customfile, AddEditStoreDetail model)
        {
            var result = false;
            var message = string.Empty;
            string removeOldLogo = string.Empty;
            if (ModelState.IsValid)
            {
                if (customfile != null)
                {
                    removeOldLogo = model.StoreLogo;
                    model.StoreLogo = Common.Common.SaveFile(Path.Combine(_environment.WebRootPath, "storeimages"), customfile);
                }

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

                #region Remove New File On Error
                if (!result && !string.IsNullOrWhiteSpace(model.StoreLogo))
                {
                    var folder = Path.Combine(_environment.WebRootPath, "storeimages");
                    var image = Path.Combine(folder, model.StoreLogo);
                    Common.Common.DeleteFile(image);
                }
                #endregion

                #region Remove Old File on Success
                if (result && !string.IsNullOrWhiteSpace(removeOldLogo))
                {
                    var folder = Path.Combine(_environment.WebRootPath, "storeimages");
                    var image = Path.Combine(folder, removeOldLogo);
                    Common.Common.DeleteFile(image);
                }

                #endregion
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

        #region Active / Inactive Store
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

        #region Delete Store
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStore([FromBody] StoreGetDeleteModel model)
        {
            var result = false;
            var message = string.Empty;

            APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(model.Id, apiUrl + "/DeleteStore", true, UserSession.JWT);
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

        #region Edit Store
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> EditStore([FromBody] StoreGetDeleteModel store)
        {
            AddEditStoreDetail model = new AddEditStoreDetail();
            if (ModelState.IsValid)
            {
                APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(store.Id, apiUrl + "/StoreGet", true, UserSession.JWT);
                if (response != null)
                {
                    model = JsonConvert.DeserializeObject<AddEditStoreDetail>(response.Data);
                }
                else
                {
                    this.AddNotification(response.Message, NotificationType.ERROR);
                }
            }

            return PartialView("_RequestStore", model);
        }

        #endregion

    }
}
