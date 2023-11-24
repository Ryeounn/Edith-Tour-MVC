using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdithTour.Controllers
{
    public class TourController : Controller
    {
        // GET: Tour
        public ActionResult Hottour()
        {
            return View();
        }
    }
}