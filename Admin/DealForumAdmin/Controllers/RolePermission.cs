using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DealForumAdmin.Controllers
{
    public class RolePermission : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
