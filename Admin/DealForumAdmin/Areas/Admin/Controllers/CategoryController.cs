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
    public class CategoryController : Controller
    {
        private readonly IOptions<AppSettingsViewModel> _appSettings;
        private static string apiUrl = string.Empty;
        private readonly IWebHostEnvironment _environment;

        public CategoryController(IOptions<AppSettingsViewModel> appSettings, IActionContextAccessor actionContext, IWebHostEnvironment iHostingEnvironment)
        {
            var routeData = actionContext.ActionContext.RouteData;
            string currentArea = Convert.ToString(routeData.Values["area"] ?? string.Empty);
            string currentController = routeData.Values["controller"].ToString();
            string key = currentArea + currentController;

            Common.Common.ByPassConAct[key] = new List<string> { "" };
            Common.Common.OnlyAuthNoRightsCheck[key] = new List<string> { };
            Common.Common.ViewRightsActions[key] = new List<string> { "Index", };
            Common.Common.ModifyRightsActions[key] = new List<string> { };

            _appSettings = appSettings;
            _environment = iHostingEnvironment;
            apiUrl = _appSettings.Value.APIEndPoint + "CategoryApi";
        }


        public IActionResult Index()
        {
            return View();
        }

        #region Get Categories List
        [HttpPost]
        public async Task<JsonResult> GetCategorysList(DataTableRequest request)
        {
            CategoryModel model = new CategoryModel();
            model.Request = request;
            var response = await Common.Common.PostMessageAsync<APIResponseModel>(model, apiUrl + "/CategoryListGet", true, UserSession.JWT);

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

        #region Add Category (GET)
        [HttpGet]
        public IActionResult AddCategory()
        {
            AddEditCategoryDetail model = new AddEditCategoryDetail();
            return PartialView("_RequestCategory", model);
        }
        #endregion

        #region Add/Update Category
        [HttpPost]
        public async Task<IActionResult> AddUpdateCategory(AddEditCategoryDetail model)
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

        #region Active / Inactive Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus([FromBody] CategoryStatusModel model)
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

        #region Delete Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory([FromBody] CategoryGetDeleteModel model)
        {
            var result = false;
            var message = string.Empty;

            APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(model.Id, apiUrl + "/DeleteCategory", true, UserSession.JWT);
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

        #region Edit Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> EditCategory([FromBody] CategoryGetDeleteModel Category)
        {
            AddEditCategoryDetail model = new AddEditCategoryDetail();
            if (ModelState.IsValid)
            {
                APIResponseModel response = await Common.Common.PostMessageAsync<APIResponseModel>(Category.Id, apiUrl + "/CategoryGet", true, UserSession.JWT);
                if (response != null)
                {
                    model = JsonConvert.DeserializeObject<AddEditCategoryDetail>(response.Data);
                }
                else
                {
                    this.AddNotification(response.Message, NotificationType.ERROR);
                }
            }

            return PartialView("_RequestCategory", model);
        }

        #endregion



    }
}
