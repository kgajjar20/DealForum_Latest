using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.Common
{
    public static class Common
    {

        public const string ClaimUserId = System.Security.Claims.ClaimTypes.NameIdentifier;
        public const string IPAddressHeader = "IP Address";
        public const string AuthorizationHeader = "Authorization";
        public const string MobileData = "MobileData";
        public const string ClaimUserType = System.Security.Claims.ClaimTypes.Role;
        public const string RequestedApp = "ClientId";

        public enum APITrackingType : int
        {
            Login = 1,
            AdminPortalLogin = 2,
            Registeration = 3,
            ForgotPassword = 4,
            Add = 5,
            Edit = 6,
            Delete = 7,
            Search = 8,
            View = 9,
            ResetPassword = 10,
            VerifyEmail = 11,
            VerifyMenuRights = 12,
            Invitation = 13,
            FileDownload = 14
        }
    }
}
