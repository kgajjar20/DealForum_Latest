using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealForum.Common;
using DealForumLibrary.Models;
using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DealForum.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DealController : Controller
    {

        private readonly IOptions<AppSettingsViewModel> _appSettings;
        private static string apiUrl = string.Empty;
        private readonly IWebHostEnvironment _environment;
        public DealController(IOptions<AppSettingsViewModel> appSettings, IWebHostEnvironment iHostingEnvironment, IActionContextAccessor actionContext)
        {
            var routeData = actionContext.ActionContext.RouteData;
            string currentArea = Convert.ToString(routeData.Values["area"] ?? string.Empty);
            string currentController = routeData.Values["controller"].ToString();
            string key = currentArea + currentController;

            Common.Common.ByPassConAct[key] = new List<string> { "" };
            Common.Common.OnlyAuthNoRightsCheck[key] = new List<string> { "Index" };
            Common.Common.ViewRightsActions[key] = new List<string> { "" };
            Common.Common.ModifyRightsActions[key] = new List<string> { "" };

            _appSettings = appSettings;
            _environment = iHostingEnvironment;
            apiUrl = _appSettings.Value.APIEndPoint + "DealApi";
        }


        public IActionResult Index()
        {
            return View();
        }

        #region Get Deals List
        [HttpPost]
        public async Task<JsonResult> GetDealsList(DataTableRequest request)
        {
            DealModel model = new DealModel();
            model.Request = request;
            var response = await Common.Common.PostMessageAsync<APIResponseModel>(model, apiUrl + "/DealListGet", true, UserSession.JWT);

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

        #region Add Deal (GET)
        [HttpGet]
        public async Task<IActionResult> AddDeal()
        {
            AddEditDealDetail model = new AddEditDealDetail();
            model.ForumList = new List<TextValueGuid>();
            string storeApiUrl = _appSettings.Value.APIEndPoint + "AdminForumApi";
            APIResponseModel response = await Common.Common.GetMessageAsync<APIResponseModel>(storeApiUrl + "/ForumsListGet", string.Empty, true, UserSession.JWT);
            if (response != null && response.Status == true)
            {
                List<ForumDetail> stores = JsonConvert.DeserializeObject<List<ForumDetail>>(response.Data);
                model.ForumList = (from x in stores select new TextValueGuid() { Text = x.Name, Value = x.Id }).ToList();
            }
            return PartialView("_RequestDeal", model);
        }
        #endregion

        #region Add/Update Deal
        [HttpPost]
        public async Task<IActionResult> AddUpdateDeal(AddEditDealDetail model)
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

        #region Active / Inactive Deal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus([FromBody] DealStatusModel model)
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

        #region Delete Deal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDeal([FromBody] DealGetDeleteModel model)
        {
            var result = false;
            var message = string.Empty;

            APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(model.Id, apiUrl + "/DeleteDeal", true, UserSession.JWT);
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

        #region Edit Deal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> EditDeal([FromBody] DealGetDeleteModel Deal)
        {
            AddEditDealDetail model = new AddEditDealDetail();
            if (ModelState.IsValid)
            {
                APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(Deal.Id, apiUrl + "/DealGet", true, UserSession.JWT);
                if (response != null)
                {
                    model = JsonConvert.DeserializeObject<AddEditDealDetail>(response.Data);
                }
                else
                {
                    this.AddNotification(response.Message, NotificationType.ERROR);
                }
            }

            return PartialView("_RequestDeal", model);
        }

        #endregion


    }
}
