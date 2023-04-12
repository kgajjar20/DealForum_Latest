using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForum.Common
{
    public static class UserSession
    {
        private static IHttpContextAccessor _accessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        public static HttpContext HttpContext => _accessor.HttpContext;

        public static Guid UserId
        {
            get
            {
                if (HttpContext.Session.GetString("UserId") == null || Guid.Parse(HttpContext.Session.GetString("UserId")) == Guid.Empty)
                    return Guid.Empty;
                else
                    return Guid.Parse(Convert.ToString(HttpContext.Session.GetString("UserId")));
            }
            set
            {
                HttpContext.Session.SetString("UserId", Convert.ToString(value));
            }
        }

        public static int? PortalType
        {
            get
            {
                if (HttpContext.Session.GetInt32("PortalType") == null)
                    return null;
                else
                    return HttpContext.Session.GetInt32("PortalType");
            }
            set
            {
                HttpContext.Session.SetInt32("PortalType", Convert.ToInt32(value));
            }
        }

        public static int? RoleId
        {
            get
            {
                if (HttpContext.Session.GetInt32("RoleId") == null)
                    return null;
                else
                    return HttpContext.Session.GetInt32("RoleId");
            }
            set
            {
                HttpContext.Session.SetInt32("RoleId", Convert.ToInt32(value));
            }
        }

        public static string RoleName
        {
            get
            {
                if (HttpContext.Session.GetString("RoleName") == null)
                    return null;
                else
                    return HttpContext.Session.GetString("RoleName");
            }
            set
            {
                HttpContext.Session.SetString("RoleName", value);
            }
        }

        public static string FirstName
        {
            get
            {
                if (HttpContext.Session.GetString("FirstName") == null)
                    return null;
                else
                    return HttpContext.Session.GetString("FirstName");
            }
            set
            {
                HttpContext.Session.SetString("FirstName", value);
            }
        }

        public static string LastName
        {
            get
            {
                if (HttpContext.Session.GetString("LastName") == null)
                    return null;
                else
                    return HttpContext.Session.GetString("LastName");
            }
            set
            {
                HttpContext.Session.SetString("LastName", value);
            }
        }
        public static string Email
        {
            get
            {
                if (HttpContext.Session.GetString("Email") == null)
                    return null;
                else
                    return HttpContext.Session.GetString("Email");
            }
            set
            {
                HttpContext.Session.SetString("Email", value);
            }
        }

        public static bool EmailVerified
        {
            get
            {
                if (HttpContext.Session.GetBoolean("EmailVerified") == null)
                    return false;
                else

                    return Convert.ToBoolean(HttpContext.Session.GetBoolean("EmailVerified"));
            }
            set
            {
                HttpContext.Session.SetBoolean("EmailVerified", value);
            }
        }

        public static bool DisplayOfficialBadge
        {
            get
            {
                if (HttpContext.Session.GetBoolean("DisplayOfficialBadge") == null)
                    return false;
                else

                    return Convert.ToBoolean(HttpContext.Session.GetBoolean("DisplayOfficialBadge"));
            }
            set
            {
                HttpContext.Session.SetBoolean("DisplayOfficialBadge", value);
            }
        }

        public static bool IsAdmin
        {
            get
            {
                if (HttpContext.Session.GetBoolean("IsAdmin") == null)
                    return false;
                else

                    return Convert.ToBoolean(HttpContext.Session.GetBoolean("IsAdmin"));
            }
            set
            {
                HttpContext.Session.SetBoolean("IsAdmin", value);
            }
        }

        public static string JWT
        {
            get
            {
                if (HttpContext.Session.GetString("JWT") == null)
                    return null;
                else
                    return HttpContext.Session.GetString("JWT");
            }
            set
            {
                HttpContext.Session.SetString("JWT", value);
            }
        }

        public static DateTime? CreatedDate
        {
            get
            {
                if (HttpContext.Session.GetObject<DateTime>("CreatedDate") == null)
                    return null;
                else
                    return HttpContext.Session.GetObject<DateTime>("CreatedDate");
            }
            set
            {
                HttpContext.Session.SetObject("CreatedDate", value);
            }

        }

        public static string ProfilePhoto
        {
            get
            {
                if (HttpContext.Session.GetString("ProfilePhoto") == null)
                    return null;
                else
                    return HttpContext.Session.GetString("ProfilePhoto");
            }
            set
            {
                value = !string.IsNullOrWhiteSpace(value) ? value : string.Empty;
                HttpContext.Session.SetString("ProfilePhoto", value);
            }
        }

        public static byte[] ProfilePhotoByte
        {
            get
            {
                if (HttpContext.Session.GetObject<byte[]>("ProfilePhotoByte") == null)
                    return null;
                else
                    return HttpContext.Session.GetObject<byte[]>("ProfilePhotoByte");
            }
            set
            {
                HttpContext.Session.SetObject("ProfilePhotoByte", value);
            }
        }

    }
}
