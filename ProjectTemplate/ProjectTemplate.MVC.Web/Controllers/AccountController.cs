using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProjectTemplate.MVC.Web.Models;

namespace ProjectTemplate.MVC.Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult Index()
        {
            return Content("登录成功");
        }
        [AllowAnonymous]
        public ActionResult TempLogin()
        {
            SignIn("123");
            return Redirect("Index");
        }
    }
}