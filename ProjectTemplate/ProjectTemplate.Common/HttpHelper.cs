using System;
using System.IO;
using System.Net;
using System.Text;

namespace ProjectTemplate.Common
{
    public static class HttpHelper
    {
        /// <summary>
        /// 获取web客户端ip
        /// </summary>
        /// <returns></returns>
        public static string GetWebClientIp()
        {

            string userIP = "未获取用户IP";

            try
            {
                if (System.Web.HttpContext.Current == null
                 || System.Web.HttpContext.Current.Request == null
                 || System.Web.HttpContext.Current.Request.ServerVariables == null)
                {
                    return "";
                }

                string CustomerIP = "";

                //CDN加速后取到的IP simone 090805
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!String.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                    if (CustomerIP == null)
                    {
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                if (string.Compare(CustomerIP, "unknown", true) == 0 || String.IsNullOrEmpty(CustomerIP))
                {
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                }
                return CustomerIP;
            }
            catch { }

            return userIP;

        }

        /// <summary>
        /// 获取html页面
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetPage(string url)
        {
            return GetPage(url, null);
        }

        public static string GetPage(string url, string userAgent)
        {
            var response = GetWebResponse(url, userAgent);
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string ss = sr.ReadToEnd();
            sr.Close();
            response.Close();
            return ss;
        }

        private static HttpWebResponse GetWebResponse(string url, string userAgent)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";
            request.KeepAlive = true;
            request.AllowAutoRedirect = false;
            if (string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
            }
            else
            {
                request.UserAgent = userAgent;
            }
            return request.GetResponse() as HttpWebResponse;
        }
    }
}