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


        public static async Task<T> GetMessageAsync<T>(string url, string body, bool isAuth = true, string JwtToken = null)
        {
            using (WebClient client = new WebClient())
            {
                if (!string.IsNullOrWhiteSpace(JwtToken))
                {
                    client.Headers.Add("Authorization", "Bearer " + JwtToken);
                }
                //client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                client.Headers.Add("Content-Type", "application/json");

                if (!string.IsNullOrEmpty(body))
                {
                    url += "?Input=" + body;
                }

                try
                {
                    var reply = await client.DownloadDataTaskAsync(url);

                    return JsonConvert.DeserializeObject<T>(Encoding.ASCII.GetString(reply));
                }
                catch (WebException wex)
                {
                    var res = ((HttpWebResponse)wex.Response);
                    if (res != null)
                    {
                        using StreamReader sr = new StreamReader(res.GetResponseStream());
                        var reply = sr.ReadToEnd();
                        return JsonConvert.DeserializeObject<T>(reply);
                    }
                }
            }

            throw new Exception("Error while getting API");
        }

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

        #region Save & Get File
        #region Save File
        /// <summary>
        /// Save file to defined path and return new file name with datetimetick
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="File"></param>
        /// <returns></returns>
        public static string SaveFile(string FilePath, IFormFile File)
        {
            string filename = "";
            try
            {
                filename = DateTime.Now.Ticks + "_" + File.FileName;
                using (var fileStream = new FileStream(FilePath + "\\" + filename, FileMode.Create, FileAccess.ReadWrite))
                {
                    File.CopyTo(fileStream);
                }
            }
            catch { }
            return filename;
        }
        #endregion

        #region Delete File
        public static bool DeleteFile(string FilePath)
        {
            bool result = false;
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                result = true;
            }
            return result;
        }

        #endregion
        #region GetFile
        public static byte[] GetFile(string FolderPath, string FileName)
        {
            byte[] fileContent = null;
            try
            {
                FileStream fs = new FileStream((FolderPath + "\\" + FileName), FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(fs);
                long byteLength = new FileInfo((FolderPath + "\\" + FileName)).Length;
                fileContent = binaryReader.ReadBytes((Int32)byteLength);
                fs.Close();
                fs.Dispose();
                binaryReader.Close();

            }
            catch (Exception)
            {
                fileContent = null;
            }
            return fileContent;
        }

        #endregion

        #region GetFileType
        public static string GetFileType(string fileExtention)
        {
            string fileType = string.Empty;
            var mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {

                  {".pdf", "application/pdf"},
                  {".doc", "application/msword"},
                  {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                  {".bmp", "image/bmp"},
                  {".jpe", "image/jpeg"},
                  {".jpeg", "image/jpeg"},
                  {".jpg", "image/jpeg"},
                  {".ppt", "application/vnd.ms-powerpoint"},
                  {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
                  {".png", "image/png"},
                  {".gif", "image/gif"},
                  {".txt", "text/plain"},
                  {".xls", "application/vnd.ms-excel"},
                  {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
            };
            mappings.TryGetValue(fileExtention, out fileType);
            return fileType;
        }
        #endregion
        #endregion
    }
}
