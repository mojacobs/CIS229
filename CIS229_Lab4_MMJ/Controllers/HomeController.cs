using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS229_Lab4_MMJ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About OC Ride Share";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact OC Ride Share";

            return View();
        }
    }
}