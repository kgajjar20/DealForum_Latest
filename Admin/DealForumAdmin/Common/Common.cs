using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DealForum.Common
{
    public static class Common
    {
        private static IHttpContextAccessor _accessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }
        public static HttpContext HttpContext => _accessor.HttpContext;

        public static IDictionary<string, List<string>> ByPassConAct = new Dictionary<string, List<string>> { { "", new List<string> { "" } } };
        public static IDictionary<string, List<string>> OnlyAuthNoRightsCheck = new Dictionary<string, List<string>> { { "", new List<string> { "" } } };
        public static IDictionary<string, List<string>> ViewRightsActions = new Dictionary<string, List<string>> { { "", new List<string> { "" } } };
        public static IDictionary<string, List<string>> ModifyRightsActions = new Dictionary<string, List<string>> { { "", new List<string> { "" } } };
        

        #region Constant Text
        public const string Admin = "Admin";
        #endregion

        #region IsAjaxRequest
        public static bool IsAjaxRequest(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Headers == null)
                return false;

            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        #endregion

        #region PostMessageAsync
        public static async Task<T> PostMessageAsync<T>(dynamic model, string url, bool isAuth = true, string JwtToken = null)
        {
            string objectIntoString = JsonConvert.SerializeObject(model, Formatting.Indented);
            using (WebClient client = new WebClient())
            {
                Uri uri = new Uri(url);
                if (isAuth && !string.IsNullOrWhiteSpace(JwtToken))
                {
                    client.Headers.Add("Authorization", "Bearer " + JwtToken);
                }
                client.Headers.Add("Content-Type", "application/json");

                string serializedObject = JsonConvert.SerializeObject(model, Formatting.Indented);
                try
                {
                    var reply = await client.UploadDataTaskAsync(uri, "POST", Encoding.ASCII.GetBytes(serializedObject));
                    return JsonConvert.DeserializeObject<T>(Encoding.ASCII.GetString(reply));
                }
                catch (WebException ex)
                {
                    var res = ((HttpWebResponse)ex.Response);
                    if (res != null)
                    {
                        using StreamReader sr = new StreamReader(res.GetResponseStream());
                        var reply = sr.ReadToEnd();
                        return JsonConvert.DeserializeObject<T>(reply);
                    }
                }
            }

            throw new Exception("Error while posting API");
        }

        #endregion


    }
}
