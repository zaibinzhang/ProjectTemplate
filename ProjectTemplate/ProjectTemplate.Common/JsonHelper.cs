using System.Web.Script.Serialization;

namespace ProjectTemplate.Common
{
    public static class JsonHelper
    {
        public static T Json<T>(string json) where T : class
        {
            return new JavaScriptSerializer().Deserialize(json, typeof(T)) as T;
        }

        public static string FromJson(object json)
        {
            return new JavaScriptSerializer().Serialize(json);
        }
    }
}