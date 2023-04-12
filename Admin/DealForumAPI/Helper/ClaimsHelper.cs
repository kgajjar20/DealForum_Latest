using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DealForumAPI.Helper
{
    public static class ClaimsHelper
    {

        public static ClaimsDetail GetClaimsDetail(ClaimsIdentity identity)
        {
            ClaimsDetail claimsDetail = new ClaimsDetail();
            claimsDetail.UserId = new Guid(identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            claimsDetail.Name = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            claimsDetail.Email = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            string portalType = identity.Claims.Where(x => x.Type == Common.Common.PortalTypeClaim).FirstOrDefault().Value;
            if (!string.IsNullOrWhiteSpace(portalType))
            {
                int portalTypeInt;
                if (int.TryParse(portalType, out portalTypeInt))
                {
                    claimsDetail.PortalType = portalTypeInt;
                }
            }
            string roleId = identity.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault()?.Value;
            if (!string.IsNullOrWhiteSpace(roleId))
            {
                int roleInt;
                if (int.TryParse(roleId, out roleInt))
                {
                    claimsDetail.RoleId = roleInt;
                }
            }
            return claimsDetail;
        }
        public static Guid GetUserId(ClaimsIdentity identity)
        {
            return new Guid(identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }

    }
    public class ClaimsDetail
    {
        public Guid UserId { get; set; }
        public int PortalType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
    }

}
