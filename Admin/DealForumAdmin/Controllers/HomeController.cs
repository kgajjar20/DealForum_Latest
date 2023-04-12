using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DealForumAdmin.Models;
using Microsoft.AspNetCore.Authorization;
using DealForum.Common;

namespace DealForumAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        #region Refresh Notification
        public ActionResult RefreshNotification()
        {
            return PartialView("_Notifications");
        }

        #endregion

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string s = null)
        {
            return RedirectToAction("Index");
        }

        public IActionResult ForgorPassword()
        {
            return View();
        }


    }
}
