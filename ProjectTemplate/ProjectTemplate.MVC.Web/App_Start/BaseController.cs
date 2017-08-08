using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ProjectTemplate.Common;
using ProjectTemplate.ViewModel;

namespace ProjectTemplate.MVC.Web
{
    public class BaseController : Controller
    {
        public Guid GetUserId()
        {
            return Guid.Parse(HttpContext.User.Identity.Name);
        }

        public JsonResult Json(string msg, Exception ex)
        {
            LogHelper.Error(msg, ex);
            return Json(ServiceResultCode.Error, msg + ":" + ex.Message);
        }

        public JsonResult Json(ServiceResultCode code, string msg)
        {
            bool isGet = HttpContext.Request.HttpMethod.ToLower() == "get";
            if (isGet)
            {
                return Json(new ServiceResult(code, msg), JsonRequestBehavior.AllowGet);
            }
            return Json(new ServiceResult(code, msg));
        }

        protected JsonResult Json<T>(ServiceResultCode code, string msg, T data) where T : class
        {
            bool isGet = HttpContext.Request.HttpMethod.ToLower() == "get";
            if (isGet)
            {
                return Json(new ServiceResult<T>(code, msg, data), JsonRequestBehavior.AllowGet);
            }
            return Json(new ServiceResult<T>(code, msg, data));
        }

        protected IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        protected void SignIn(string userId)
        {
            AuthenticationManager.SignOut();
            ClaimsIdentity i = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            i.AddClaim(new Claim(ClaimTypes.Name, userId));
            AuthenticationManager.SignIn(i);
        }

        protected JsonResult Json(Func<object> action, string error = null)
        {
            bool isGet = HttpContext.Request.HttpMethod.ToLower() == "get";
            try
            {
                if (isGet)
                {
                    return Json(action(), JsonRequestBehavior.AllowGet);
                }
                return Json(action());
            }
            catch (Exception e)
            {
                LogHelper.Error(error, e);
                return Json(ServiceResultCode.Error, string.IsNullOrEmpty(error) ? e.Message : error + ":" + e.Message);
            }
        }
    }
}