using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using ProjectTemplate.MVC.Web.Models;

namespace ProjectTemplate.MVC.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                CookieName = "AuthTicket",
                ExpireTimeSpan = new TimeSpan(0, 2, 0, 0),
                Provider = new CookieAuthenticationProvider
                {
                    OnApplyRedirect = ctx =>
                    {
                        if (!IsAjaxRequest(ctx.Request))
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                    }
                },
            });
        }

        private bool IsAjaxRequest(IOwinRequest request)
        {
            IReadableStringCollection query = request.Query;
            if (query != null && query["X-Requested-With"] == "XMLHttpRequest")
            {
                return true;
            }
            IHeaderDictionary headers = request.Headers;
            return headers != null && headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}