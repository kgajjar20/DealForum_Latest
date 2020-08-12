using DealForumAPI.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DealForumAPI.Common.ExceptionTracking;

namespace DealForumAPI.Common
{
    public interface IException
    {
        Task<Apiexceptiontracking> SaveExceptionTracking(string Exception);
        Task<Apiexceptiontracking> SaveExceptionTracking(ApiExceptionModel model);
    }

    public class ExceptionTracking : IException
    {
        private readonly DealForumContext _Context;
        private readonly HttpContext _HttpContext;

        public ExceptionTracking(DealForumContext Context, IHttpContextAccessor contextAccessor)
        {
            _Context = Context;
            _HttpContext = contextAccessor.HttpContext;
        }
        public async Task<Apiexceptiontracking> SaveExceptionTracking(string Exception)
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
                    if (logInUserPortalTypeClaim != null)
                    {
                        logInUserPortalType = Convert.ToInt32(logInUserPortalTypeClaim.Value);
                    }

                    var model = new ApiExceptionModel
                    {
                        TraceId = _HttpContext.TraceIdentifier,
                        Exception = Exception,
                        Controller = controllerName?.ToString(),
                        Action = actionName?.ToString(),
                        HttpMethod = _HttpContext.Request.Method,
                        URL = UriHelper.GetDisplayUrl(_HttpContext.Request),
                        UserId = logInUserId,
                        PortalType = logInUserPortalType,
                    };
                    //return SaveExceptionTracking(model).Result;
                    var _apiexcptionmodel = new Apiexceptiontracking
                    {
                        Traceid = model.TraceId,
                        Exception = model.Exception,
                        Controller = model.Controller,
                        Action = model.Action,
                        Httpmethod = model.HttpMethod,
                        Url = model.URL,
                        Userid = model.UserId,
                        Portaltype = model.PortalType,
                        Exceptiontime = DateTime.Now
                    };
                    _Context.Apiexceptiontracking.AddAsync(_apiexcptionmodel);
                    _Context.SaveChangesAsync();
                    return _apiexcptionmodel;
                }
                catch
                {
                    return new Apiexceptiontracking();
                }
            });
        }

        public async Task<Apiexceptiontracking> SaveExceptionTracking(ApiExceptionModel model)
        {
            return await Task.Run(() =>
            {
                var _apiexcptionmodel = new Apiexceptiontracking
                {
                    Traceid = model.TraceId,
                    Exception = model.Exception,
                    Controller = model.Controller,
                    Action = model.Action,
                    Httpmethod = model.HttpMethod,
                    Url = model.URL,
                    Userid = model.UserId,
                    Portaltype = model.PortalType,
                    Exceptiontime = DateTime.Now
                };
                _Context.Apiexceptiontracking.AddAsync(_apiexcptionmodel);
                _Context.SaveChangesAsync();
                return _apiexcptionmodel;
            });
        }

        public class ApiExceptionModel
        {
            public string TraceId { get; set; }
            public string Exception { get; set; }
            public string Controller { get; set; }
            public string Action { get; set; }
            public string HttpMethod { get; set; }
            public string URL { get; set; }
            public Guid? UserId { get; set; }
            public int? PortalType { get; set; }
        }
    }
}
