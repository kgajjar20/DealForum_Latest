using DealForumAPI.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealForumLibrary;
using Microsoft.EntityFrameworkCore;
using DealForumLibrary.EnumHelper;

namespace DealForumAPI.Common.LogTracking
{
    public interface IApiLogTrackingRepo
    {
        Task SaveAPILogTracking(LogTrackingModel logModel);
    }
    public class LogTrackingRepo : IApiLogTrackingRepo
    {
        private readonly DealForumContext _Context;
        public LogTrackingRepo(DealForumContext context)
        {
            _Context = context;
        }
        public async Task SaveAPILogTracking(LogTrackingModel logModel)
        {
            try
            {
                var _apiLogTrackingModel = new Apilogtracking();
                if (logModel.LogTrackingType == (int)EnumHelper.APILogTrackingType.Request)
                {
                    _apiLogTrackingModel.Traceid = logModel.TraceId;
                    _apiLogTrackingModel.Ipaddress = logModel.IPAddress;
                    _apiLogTrackingModel.Httpmethod = logModel.HttpMethod;
                    _apiLogTrackingModel.Apiname = logModel.ApiName;
                    _apiLogTrackingModel.Requesttime = DateTime.Now;
                    _apiLogTrackingModel.Requestbody = logModel.RequestResponseBody;
                    _apiLogTrackingModel.Requestedby = logModel.RequestedBy;
                    _apiLogTrackingModel.Requestedfrom = logModel.RequestedFrom;
                    _apiLogTrackingModel.Url = logModel.URL;
                    _apiLogTrackingModel.Requestedapp = logModel.RequestedApp;
                    _apiLogTrackingModel.Mobiledata = logModel.MobileData;
                    _apiLogTrackingModel.Authtoken = logModel.AuthToken;

                    await _Context.Apilogtracking.AddAsync(_apiLogTrackingModel);
                }
                else
                {
                    _apiLogTrackingModel = _Context.Apilogtracking.Where(X => X.Traceid == logModel.TraceId).FirstOrDefault();
                    if (_apiLogTrackingModel != null)
                    {
                        _apiLogTrackingModel.Responsebody = logModel.RequestResponseBody;
                        _apiLogTrackingModel.Responsetime = DateTime.Now;
                        _Context.Entry(_apiLogTrackingModel).State = EntityState.Modified;
                    }

                }
                await _Context.SaveChangesAsync();
            }
            catch { }
        }
    }
    public class LogTrackingModel
    {
        public Guid Id { get; set; }
        public int LogTrackingType { get; set; }
        public string TraceId { get; set; }
        public string IPAddress { get; set; }
        public string HttpMethod { get; set; }
        public string ApiName { get; set; }
        public string RequestResponseBody { get; set; }
        public int? RequestedBy { get; set; }
        public int? RequestedFrom { get; set; }
        public string URL { get; set; }
        public string RequestedApp { get; set; }
        public string MobileData { get; set; }
        public string AuthToken { get; set; }
    }
}
