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
    public class CouponController : Controller
    {
        private readonly IOptions<AppSettingsViewModel> _appSettings;
        private static string apiUrl = string.Empty;
        private readonly IWebHostEnvironment _environment;
        public CouponController(IOptions<AppSettingsViewModel> appSettings, IWebHostEnvironment iHostingEnvironment, IActionContextAccessor actionContext)
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
            apiUrl = _appSettings.Value.APIEndPoint + "CouponApi";
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Get Coupons List
        [HttpPost]
        public async Task<JsonResult> GetCouponsList(DataTableRequest request)
        {
            CouponModel model = new CouponModel();
            model.Request = request;
            var response = await Common.Common.PostMessageAsync<APIResponseModel>(model, apiUrl + "/CouponListGet", true, UserSession.JWT);

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

        #region Add Coupon (GET)
        [HttpGet]
        public async Task<IActionResult> AddCoupon()
        {
            AddEditCouponDetail model = new AddEditCouponDetail();
            model.StoreList = new List<TextIntValue>();
            string storeApiUrl = _appSettings.Value.APIEndPoint + "AdminStoreApi";
            APIResponseModel response = await Common.Common.GetMessageAsync<APIResponseModel>(storeApiUrl + "/StoreListGet", string.Empty, true, UserSession.JWT);
            if (response != null && response.Status == true)
            {
                List<StoreDetail> stores = JsonConvert.DeserializeObject<List<StoreDetail>>(response.Data);
                model.StoreList = (from x in stores select new TextIntValue() { Text = x.Name, Value = x.Id }).ToList();
            }

            return PartialView("_RequestCoupon", model);
        }
        #endregion

        #region Add/Update Coupon
        [HttpPost]
        public async Task<IActionResult> AddUpdateCoupon(AddEditCouponDetail model)
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

        #region Active / Inactive Coupon
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus([FromBody] CouponStatusModel model)
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

        #region Delete Coupon
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCoupon([FromBody] CouponGetDeleteModel model)
        {
            var result = false;
            var message = string.Empty;

            APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(model.Id, apiUrl + "/DeleteCoupon", true, UserSession.JWT);
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

        #region Edit Coupon
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> EditCoupon([FromBody] CouponGetDeleteModel Coupon)
        {
            AddEditCouponDetail model = new AddEditCouponDetail();
            if (ModelState.IsValid)
            {
                APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(Coupon.Id, apiUrl + "/CouponGet", true, UserSession.JWT);
                if (response != null)
                {
                    model = JsonConvert.DeserializeObject<AddEditCouponDetail>(response.Data);
                }
                else
                {
                    this.AddNotification(response.Message, NotificationType.ERROR);
                }
            }
         
            return PartialView("_RequestCoupon", model);
        }

        #endregion
    }
}
