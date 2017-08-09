using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using ProjectTemplate.Common;
using ProjectTemplate.IBusiness;

namespace ProjectTemplate.MVC.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ITestServer _testServer = InstanceFactory.GetInstance<ITestServer>();

        public ActionResult Index()
        {
            _testServer.Test();
            LogHelper.Error("这是error");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}