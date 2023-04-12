using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealForumLibrary;

namespace DealForumAPI.Common.LogTracking
{

    public class APIRequestResponseRewindMiddleware
    {
        private readonly RequestDelegate _Next;
        public APIRequestResponseRewindMiddleware(RequestDelegate next)
        {
            _Next = next;
        }
        public async Task Invoke(HttpContext httpContext, IApiLogTrackingRepo apiLogTrackingRepo)
        {
            Stream originalRequestBody = httpContext.Request.Body;
            bool isErrorOnRequest = false;
            try
            {
                var routeData = httpContext.GetRouteData();
                string currentArea = Convert.ToString(routeData.Values["area"] ?? string.Empty);
                string currentAction = Convert.ToString(routeData.Values["action"]);
                string currentController = Convert.ToString(routeData.Values["controller"]);

                //var requestHeaders = APIRequestResponseTool.SerializeHeaders(filterContext.HttpContext.Request.Headers);
                var requstedApp = httpContext.Request.Headers.Where(h => string.Compare(h.Key, Common.RequestedApp, true) == 0).FirstOrDefault().Value;
                var mobileData = httpContext.Request.Headers.Where(h => string.Compare(h.Key, Common.MobileData, true) == 0).FirstOrDefault().Value;
                var authHeader = httpContext.Request.Headers.Where(h => string.Compare(h.Key, Common.AuthorizationHeader, true) == 0).FirstOrDefault().Value;
                var ipAddressHeader = httpContext.Request.Headers.Where(h => string.Compare(h.Key, Common.IPAddressHeader, true) == 0).FirstOrDefault().Value;

                var url = UriHelper.GetDisplayUrl(httpContext.Request);
                var traceid = httpContext.TraceIdentifier;
                var requestedByClaim = httpContext.User.Claims.Where(c => c.Type == Common.ClaimUserId).FirstOrDefault();
                int? requestedBy = null;
                if (requestedByClaim != null)
                {
                    requestedBy = int.Parse(requestedByClaim.Value);
                }
                var requestedFromClaim = httpContext.User.Claims.Where(c => c.Type == Common.ClaimUserType).FirstOrDefault();
                int? requestedFrom = null;
                if (requestedFromClaim != null)
                {
                    requestedFrom = Convert.ToInt32(requestedFromClaim.Value);
                }

                httpContext.Request.EnableBuffering();
                using (var reader = new StreamReader(
                     httpContext.Request.Body,
                     encoding: Encoding.UTF8,
                     detectEncodingFromByteOrderMarks: false,
                     //bufferSize: 8192,
                     leaveOpen: true))
                {
                    var requestBody = await reader.ReadToEndAsync();

                    var logModel = new LogTrackingModel()
                    {
                        LogTrackingType = (int)EnumHelper.APILogTrackingType.Request,
                        TraceId = traceid,
                        IPAddress = ipAddressHeader.Count > 0 ? ipAddressHeader.First() : null,
                        HttpMethod = httpContext.Request.Method,
                        ApiName = $"{(!string.IsNullOrWhiteSpace(currentArea) ? "/" + currentArea.Trim() : string.Empty)}/{currentController.Trim()}{(!string.IsNullOrWhiteSpace(currentAction) ? "/" + currentAction.Trim() : string.Empty)}",
                        RequestResponseBody = requestBody,
                        RequestedBy = (requestedBy != null) ? requestedBy.Value : (int?)null,
                        //RequestedFrom = requestedFrom,
                        URL = url,
                        RequestedApp = requstedApp.Count > 0 ? requstedApp.First().Trim() : null,
                        MobileData = mobileData.Count > 0 ? mobileData.First() : null,
                        AuthToken = authHeader.Count > 0 ? authHeader.First() : null
                    };
                    await apiLogTrackingRepo.SaveAPILogTracking(logModel);

                    httpContext.Request.Body.Position = 0;
                }
            }
            catch
            {
                isErrorOnRequest = true;
                httpContext.Request.Body = originalRequestBody;
            }

            if (!isErrorOnRequest)
            {
                Stream originalBody = httpContext.Response.Body;
                try
                {
                    //var responseHeaders = CommonLoggingTools.SerializeHeaders(filterContext.HttpContext.Response.Headers);
                    using (var memStream = new MemoryStream())
                    {
                        httpContext.Response.Body = memStream;

                        await _Next(httpContext);

                        memStream.Position = 0;
                        string responseBody = new StreamReader(memStream).ReadToEnd();
                        var logModel = new LogTrackingModel()
                        {
                            LogTrackingType = (int)EnumHelper.APILogTrackingType.Response,
                            TraceId = httpContext.TraceIdentifier,
                            RequestResponseBody = $"{httpContext.Response.StatusCode}: {responseBody}"
                        };

                        await apiLogTrackingRepo.SaveAPILogTracking(logModel);

                        memStream.Position = 0;

                        await memStream.CopyToAsync(originalBody);
                    }

                }
                finally
                {
                    httpContext.Response.Body = originalBody;
                }
            }
            else
            {
                await _Next(httpContext);
            }
        }
    }
}
