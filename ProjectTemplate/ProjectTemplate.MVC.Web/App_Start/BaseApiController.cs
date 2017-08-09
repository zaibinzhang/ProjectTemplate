using System;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ProjectTemplate.Common;
using ProjectTemplate.ViewModel;

namespace ProjectTemplate.MVC.Web
{
    public class BaseApiController : ApiController
    {
        protected object Json(Antlr.Runtime.Misc.Func<object> action, string error = null)
        {
            try
            {
                return action();
            }
            catch (Exception e)
            {
                LogHelper.Error(error, e);
                return new ServiceResult(ServiceResultCode.Error, string.IsNullOrEmpty(error) ? e.Message : error + ":" + e.Message);
            }
        }

        protected void SignIn(string userId)
        {
            AuthenticationManager.SignOut();
            ClaimsIdentity i = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            i.AddClaim(new Claim(ClaimTypes.Name, userId));
            AuthenticationManager.SignIn(i);
        }

        protected IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;
    }
}