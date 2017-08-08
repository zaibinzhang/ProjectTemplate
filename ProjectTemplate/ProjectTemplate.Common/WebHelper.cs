using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Web;

namespace ProjectTemplate.Common
{
    public static class WebHelper
    {
        public static Guid GetCurrentUserId()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return Guid.Parse(HttpContext.Current.User.Identity.Name);
            }
            return Guid.Empty;
        }

        public static List<dynamic> GetEmunList<T>() where T : struct, IConvertible
        {
            var list = new List<dynamic>();
            dynamic dynull = new ExpandoObject();
            dynull.key = null;
            dynull.value = "全部";
            list.Add(dynull);
            Type t = typeof(T);
            foreach (int statusIndex in Enum.GetValues(t))
            {
                dynamic dy = new ExpandoObject();
                dy.key = statusIndex;
                T type = (T)(object)statusIndex;
                string objName = type.ToString();
                FieldInfo fi = t.GetField(objName);
                dy.value = ExHelper.GetDescription(t, fi);
                list.Add(dy);
            }
            return list;
        }


    }
}