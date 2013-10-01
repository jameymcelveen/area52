using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc4Testpad.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			ViewBag.Message = string.Format ("I modified this from the VS2010 Asp.Net MVC4 Web Application Template to run on Mono. " +
			                                 "System.Environment reports Framework Version {0}, OS Version {1}." +
			                                 "See http://www.cafe-encounter.net/p1319/run-asp-net-mvc4-on-mono-monodevelop-on-mac-the-c-template-project for other details.", 
			                                 Environment.Version, 
			                                 Environment.OSVersion);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
