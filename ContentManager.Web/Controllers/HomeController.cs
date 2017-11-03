using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult EditContent()
        {
            return RedirectToAction("Index", "ContentManagement");
            //return RedirectToAction("../ContentManagement/Index");
        }

        public ActionResult EditPois()
        {
            return RedirectToAction("PointofInterest", "ContentManagement");
            //return RedirectToAction("../ContentManagement/Index");
        }
    }
}