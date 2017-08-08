using System;
using System.ComponentModel;
using System.Reflection;

namespace ProjectTemplate.Common
{
    public static class ExHelper
    {
        public static string GetDefaultUrl(this System.Web.Mvc.HtmlHelper helper)
        {
            return HtmlHelper.GetDefaultUrl();
        }

        public static string ToCommonString(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToDateString(this DateTime time)
        {
            return time.ToString("yyyyMMdd");
        }

        public static string GetDescription(this Enum obj)
        {
            string objName = obj.ToString();
            Type t = obj.GetType();
            FieldInfo fi = t.GetField(objName);
            return GetDescription(t, fi);
        }

        internal static string GetDescription(Type t, FieldInfo fi)
        {
            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (arrDesc.Length > 0)
            {
                return arrDesc[0].Description;
            }
            return String.Empty;
        }
    }
}