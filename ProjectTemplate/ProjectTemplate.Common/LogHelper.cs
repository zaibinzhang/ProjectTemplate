using System;
using System.IO;
using System.Reflection;
using System.Web.Hosting;
using log4net;
using log4net.Config;

namespace ProjectTemplate.Common
{
    public static class LogHelper
    {
        private static string _configFile = "log.config";

        private static ILog _log;

        static LogHelper()
        {
            string dir = HostingEnvironment.MapPath("~/");
            string path = Path.Combine(dir, _configFile);
            XmlConfigurator.Configure(new FileInfo(path));
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static void Debug(string msg, Exception ex = null)
        {
            EvalLog(MethodBase.GetCurrentMethod().Name, msg, ex);
        }

        public static void Info(string msg, Exception ex = null)
        {
            EvalLog(MethodBase.GetCurrentMethod().Name, msg, ex);
        }

        public static void Warn(string msg, Exception ex = null)
        {
            EvalLog(MethodBase.GetCurrentMethod().Name, msg, ex);
        }

        public static void Error(string msg, Exception ex = null)
        {
            EvalLog(MethodBase.GetCurrentMethod().Name, msg, ex);
        }

        public static void Fatal(string msg, Exception ex = null)
        {
            EvalLog(MethodBase.GetCurrentMethod().Name, msg, ex);
        }

        private static void EvalLog(string method, string msg, Exception ex = null)
        {
            Type type = typeof(ILog);
            MethodInfo tmethod;
            object[] objParameters;
            if (ex == null)
            {
                tmethod = type.GetMethod(method, new Type[] { typeof(object) });
                objParameters = new object[] { msg };
            }
            else
            {
                tmethod = type.GetMethod(method, new Type[] { typeof(object), typeof(Exception) });
                objParameters = new object[] { msg, ex };
            }
            if (tmethod == null)
            {
                _log.Fatal($"无法反射log4net方法。type:[{type}];method:[{method}]");
            }
            else
            {
                tmethod.Invoke(_log, objParameters);
            }
        }
    }
}