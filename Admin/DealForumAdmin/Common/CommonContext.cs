using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForum.Common
{
    public class CommonContext
    {

        private readonly IOptions<AppSettingsViewModel> _AppSettings;
        private readonly HttpContext _HttpContext;
        public CommonContext(IOptions<AppSettingsViewModel> appSettings, IHttpContextAccessor contextAccessor)
        {
            _AppSettings = appSettings;
            _HttpContext = contextAccessor.HttpContext;
        }

        public static bool ViewRights { get; set; }
        public static bool ModifyRights { get; set; }

        public const string LoginPath = "Home/Login";
        public const string AdminLoginPath = "Admin/Home/Login";
        public const string UnauthorizePath = "Unauthorize/Index";
        public const string AdminUnauthorizePath = "Admin/Unauthorize/Index";
        public const string UnauthorizeMessage = "You are not authorized to perform this action.";

    }
}
