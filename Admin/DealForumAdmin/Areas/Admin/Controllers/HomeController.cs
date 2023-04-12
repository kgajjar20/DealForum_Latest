using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealForum.Common;
using DealForumLibrary.Models;
using DealForumLibrary.Models.AdminAreaModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static DealForumLibrary.EnumHelper;

namespace DealForum.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        private readonly IOptions<AppSettingsViewModel> _appSettings;
        static string apiUrl = string.Empty;

        public HomeController(IOptions<AppSettingsViewModel> appSettings, IActionContextAccessor actionContext)
        {
            var routeData = actionContext.ActionContext.RouteData;
            string currentArea = Convert.ToString(routeData.Values["area"] ?? string.Empty);
            string currentController = routeData.Values["controller"].ToString();
            string key = currentArea + currentController;

            Common.Common.ByPassConAct[key] = new List<string> { "Login", "ForgotPassword" };
            Common.Common.OnlyAuthNoRightsCheck[key] = new List<string> { };
            Common.Common.ViewRightsActions[key] = new List<string> { "Index", };
            Common.Common.ModifyRightsActions[key] = new List<string> { };

            _appSettings = appSettings;
            apiUrl = _appSettings.Value.APIEndPoint + "AdminAuthenticationApi";
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await Common.Common.PostMessageAsync<APIResponseModel>(model, apiUrl, false, null);
                if (response.Status == true && response.Code == (int)LoginStatus.Success)
                {
                    UserModel user = JsonConvert.DeserializeObject<UserModel>(response.Data);
                    if (user != null)
                    {
                        UserSession.FirstName = user.Firstname;
                        UserSession.LastName = user.Lastname;
                        UserSession.Email = user.Email;
                        UserSession.JWT = user.JWT;
                        UserSession.PortalType = (int)PortalType.Admin;
                        UserSession.UserId = user.Id;
                        UserSession.RoleId = user.RoleId;
                        UserSession.RoleName = user.RoleName;
                        UserSession.EmailVerified = user.Emailverified;
                        UserSession.DisplayOfficialBadge = user.Displayofficialbadge;
                        UserSession.IsAdmin = user.IsAdmin;
                        UserSession.CreatedDate = user.CreatedDate;
                        UserSession.ProfilePhoto = user.ProfilePhoto;
                        return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
                    }
                }
                else
                {
                    this.AddNotification(response.Message, NotificationType.ERROR);
                }
            }
            else
            {
                var message = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                this.AddNotification(message, NotificationType.INFO);
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home", new { Area = "Admin" });
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(AdminForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                this.AddNotification("mail sent successfully without logic.", NotificationType.SUCCESS);
                return RedirectToAction("Login", "Home", new { Area = "Admin" });
            }
            else
            {
                var message = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                this.AddNotification(message, NotificationType.INFO);
                return View();
            }
        }

    }
}
