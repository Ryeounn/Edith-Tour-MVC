using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdithTour.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Policy()
        {
            return View();
        }

        public ActionResult Cancel()
        {
            return View();
        }

        public ActionResult Rules()
        {
            return View();
        }

        public ActionResult Introduction()
        {
            return View();
        }
    }
}