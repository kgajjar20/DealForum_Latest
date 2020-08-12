using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealForumLibrary.EnumHelper;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DealForum.Models;

namespace DealForum.Common
{
    public class CustomFilterAttribute : ActionFilterAttribute
    {
        private readonly IOptions<AppSettingsViewModel> _AppSettings;
        private readonly CommonContext _CommonContext;
        public CustomFilterAttribute(IOptions<AppSettingsViewModel> appSettings, CommonContext commonContext)
        {
            _AppSettings = appSettings;
            _CommonContext = commonContext;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string redirectFailedUrl = "";
            var routeData = filterContext.RouteData;
            string currentArea = Convert.ToString(routeData.Values["area"] ?? string.Empty);
            string currentAction = routeData.Values["action"].ToString();
            string currentController = routeData.Values["controller"].ToString();
            string DKey = currentArea + currentController;
            var context = filterContext.HttpContext;
            int status = 1;
            bool hasAccess = false;

            if (string.IsNullOrEmpty(currentArea))
            {
                //Check here if session timeout then redirect to login again

                //Also check
                if (Common.ByPassConAct != null && Common.ByPassConAct.Any(c => c.Key == DKey && c.Value.Any(d => d == currentAction)))
                {
                    //Do nothing here
                }
                else
                {
                    if (UserSession.UserId != Guid.Empty && (UserSession.PortalType.HasValue))
                    {
                        if (UserSession.PortalType.Value == (int)EnumHelper.PortalType.Client)
                        {
                            //Here Logic to check the Current Client rights
                            //This is pending to manage as client module is pending to develop
                        }
                        else
                        {
                            redirectFailedUrl = _AppSettings.Value.SiteURL + CommonContext.LoginPath;
                        }
                    }
                    else
                    {
                        //status = 0;
                        //redirectFailedUrl = _AppSettings.Value.SiteURL + CommonContext.LoginPath;
                        //Manage to go out of system if no session available
                    }
                }
            }
            else if (currentArea.ToLower() == Common.Admin.ToLower())
            {
                if (Common.ByPassConAct != null && Common.ByPassConAct.Any(c => c.Key == DKey && c.Value.Any(d => d == currentAction)))
                {
                    //Do nothing here
                }
                else
                {
                    if (UserSession.UserId != Guid.Empty && UserSession.IsAdmin)
                    {
                        if (Common.OnlyAuthNoRightsCheck != null && Common.OnlyAuthNoRightsCheck.Any(c => c.Key == DKey && c.Value.Any(d => d == currentAction)))
                        {
                            //Do nothing here
                        }
                        else
                        {
                            //Here Logic to check the Current rights
                            hasAccess = true;//_CommonContext.AccessToActionsValidate(currentController, currentAction, currentArea);

                            if (!hasAccess)
                            {
                                if (!Common.IsAjaxRequest(context.Request))
                                {
                                    string miscRouteURL = Path.Combine(_AppSettings.Value.SiteURL, CommonContext.AdminUnauthorizePath);

                                    status = 0;
                                    redirectFailedUrl = miscRouteURL;
                                }
                                else
                                {
                                    //For AJAX
                                    var redirectURL = Path.Combine(_AppSettings.Value.SiteURL, CommonContext.AdminUnauthorizePath);

                                    var result = JsonConvert.SerializeObject(new AjaxResponseModel()
                                    {
                                        IsSuccess = false,
                                        ResponseMessage = CommonContext.UnauthorizeMessage,
                                        RedirectURL = redirectURL
                                    });

                                    filterContext.HttpContext.Response.ContentType = "application/json";
                                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                    filterContext.HttpContext.Response.WriteAsync(result);

                                    status = 0;
                                    redirectFailedUrl = redirectURL;
                                }
                            }
                        }
                    }
                    else
                    {
                        status = 0;
                        redirectFailedUrl = _AppSettings.Value.SiteURL + CommonContext.AdminLoginPath;
                        //Manage to go out of system if no session available
                    }
                }
            }
            //Provide Area wise condition here

            if (status == 1)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult(redirectFailedUrl);
                base.OnActionExecuting(filterContext);
            }
        }
    }

    public class AppSettingsViewModel
    {
        public string APIEndPoint { get; set; }
        public string SiteURL { get; set; }
        public string SiteURLCompany { get; set; }
        public string PDFKey { get; set; }
    }
}
