using System.Web;

namespace ProjectTemplate.Common
{
    public static class HtmlHelper
    {
        public static string GetDefaultUrl()
        {
            string port = string.Empty;
            if (HttpContext.Current.Request.Url.Port != 80)
            {
                port = ":" + HttpContext.Current.Request.Url.Port;
            }
            var url = $"http://{HttpContext.Current.Request.Url.Host.Trim('/')}{port}/";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.ApplicationPath))
            {
                url += HttpContext.Current.Request.ApplicationPath.Trim('/') + "/";
            }
            return url;
        }
    }
}