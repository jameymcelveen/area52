using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Area52.Models;

namespace Mvc4Testpad.Controllers
{
    public class HomeController : Controller
    {
		public DataContext data = new DataContext();

        public ActionResult Index()
        {
			ViewBag.DataContext = data;
            return View(data);
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
