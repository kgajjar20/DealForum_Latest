using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.Common
{
    public class CommonConstants
    {
        public const string ClaimUserId = System.Security.Claims.ClaimTypes.NameIdentifier;
        public const string IPAddressHeader = "IP Address";
        public const string AuthorizationHeader = "Authorization";
        public const string MobileData = "MobileData";
        public const string ClaimUserType = System.Security.Claims.ClaimTypes.Role;
        public const string RequestedApp = "ClientId";
        public const string PortalType = "PortalType";
    }
}
