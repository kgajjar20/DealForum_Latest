using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealForum.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;

namespace DealForum.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IOptions<AppSettingsViewModel> _appSettings;
        static string apiUrl = string.Empty;

        public DashboardController(IOptions<AppSettingsViewModel> appSettings, IActionContextAccessor actionContext)
        {
            var routeData = actionContext.ActionContext.RouteData;
            string currentArea = Convert.ToString(routeData.Values["area"] ?? string.Empty);
            string currentController = routeData.Values["controller"].ToString();
            string key = currentArea + currentController;

            Common.Common.ByPassConAct[key] = new List<string> { "" };
            Common.Common.OnlyAuthNoRightsCheck[key] = new List<string> { "Index" };
            Common.Common.ViewRightsActions[key] = new List<string> {  };
            Common.Common.ModifyRightsActions[key] = new List<string> { };

            _appSettings = appSettings;
        }

        
        public IActionResult Index()
        {
            return View();
        }
    }
}
