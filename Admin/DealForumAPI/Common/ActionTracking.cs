using DealForumAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.Common
{
    public interface IActionTracking
    {
        Task<Apiactiontracking> SaveAPIActionTracking(int actionTypeId, string description);
        Task<Apiactiontracking> SaveAPIActionTracking(APIActionTrackingModel apiActionModel);
    }


    public class ActionTracking : IActionTracking
    {
        private readonly DealForumContext _Context;
        private readonly HttpContext _HttpContext;
        public ActionTracking(DealForumContext context, IHttpContextAccessor contextAccessor)
        {
            _Context = context;
            _HttpContext = contextAccessor.HttpContext;
        }

        public async Task<Apiactiontracking> SaveAPIActionTracking(int actionTypeId, string description)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var routeData = _HttpContext.GetRouteData();
                    var controllerName = routeData.Values["controller"];
                    var actionName = routeData.Values["action"];

                    var logInUserIdClaim = _HttpContext.User.Claims.Where(c => c.Type == CommonConstants.ClaimUserId).FirstOrDefault();
                    Guid? logInUserId = null;
                    if (logInUserIdClaim != null)
                    {
                        logInUserId = new Guid(logInUserIdClaim.Value);
                    }
                    var logInUserPortalTypeClaim = _HttpContext.User.Claims.Where(c => c.Type == CommonConstants.PortalType).FirstOrDefault();
                    int? logInUserPortalType = null;
                    if (logInUserPortalType != null)
                    {
                        logInUserPortalType = Convert.ToInt32(logInUserPortalTypeClaim.Value);
                    }
                    var model = new APIActionTrackingModel
                    {
                        TraceId = _HttpContext.TraceIdentifier,
                        ActionTypeId = actionTypeId,
                        Description = !string.IsNullOrWhiteSpace(description) ? description : string.Empty,
                        Controller = controllerName?.ToString(),
                        Action = actionName?.ToString(),
                        HttpMethod = _HttpContext.Request.Method,
                        URL = UriHelper.GetDisplayUrl(_HttpContext.Request),
                        UserId = logInUserId,
                        PortalType = logInUserPortalType
                    };

                    var _apiActionModel = new Apiactiontracking
                    {
                        Traceid = model.TraceId,
                        Actiontypeid = model.ActionTypeId,
                        Description = !string.IsNullOrWhiteSpace(model.Description) ? model.Description : string.Empty,
                        Controller = !string.IsNullOrWhiteSpace(model.Controller) ? model.Controller : null,
                        Action = !string.IsNullOrWhiteSpace(model.Action) ? model.Action : null,
                        Httpmethod = model.HttpMethod,
                        Url = !string.IsNullOrWhiteSpace(model.URL) ? model.URL : null,
                        Userid = model.UserId.HasValue && model.UserId.Value != Guid.Empty ? model.UserId.Value : (Guid?)null,
                        Portaltype = model.PortalType
                    };
                    _apiActionModel.Actiontypeid = model.ActionTypeId;
                    _apiActionModel.Actiontime = DateTime.Now;
                    _Context.Apiactiontracking.Add(_apiActionModel);
                    _Context.SaveChangesAsync();
                    return _apiActionModel;
                }
                catch
                {
                    return new Apiactiontracking();
                }
            });
        }


        public async Task<Apiactiontracking> SaveAPIActionTracking(APIActionTrackingModel apiActionModel)
        {
            return await Task.Run(() =>
            {
                var _apiActionModel = new Apiactiontracking
                {
                    Traceid = apiActionModel.TraceId,
                    Actiontypeid = apiActionModel.ActionTypeId,
                    Description = !string.IsNullOrWhiteSpace(apiActionModel.Description) ? apiActionModel.Description : string.Empty,
                    Controller = !string.IsNullOrWhiteSpace(apiActionModel.Controller) ? apiActionModel.Controller : null,
                    Action = !string.IsNullOrWhiteSpace(apiActionModel.Action) ? apiActionModel.Action : null,
                    Httpmethod = apiActionModel.HttpMethod,
                    Url = !string.IsNullOrWhiteSpace(apiActionModel.URL) ? apiActionModel.URL : null,
                    Userid = apiActionModel.UserId.HasValue && apiActionModel.UserId.Value != Guid.Empty ? apiActionModel.UserId.Value : (Guid?)null,
                    Portaltype = apiActionModel.PortalType
                };
                _apiActionModel.Actiontypeid = apiActionModel.ActionTypeId;
                _apiActionModel.Actiontime = DateTime.Now;
                _Context.Apiactiontracking.Add(_apiActionModel);
                _Context.SaveChangesAsync();
                return _apiActionModel;
            });
        }
    }


    public class APIActionTrackingModel
    {
        public string TraceId { get; set; }
        public int ActionTypeId { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string HttpMethod { get; set; }
        public string URL { get; set; }
        public Guid? UserId { get; set; }
        public int? PortalType { get; set; }
    }
}
