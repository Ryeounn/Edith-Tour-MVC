using EdithTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdithTour.Controllers
{
    public class TourController : Controller
    {
        EdithTourEntities db = new EdithTourEntities();
        // GET: Tour
        public ActionResult Inside()
        {
            List<Tour_Inside> inside = new List<Tour_Inside>();
            return View(inside);
        }
        public ActionResult Outside()
        {
            return View();
        }

        public ActionResult Foreign() {
            return View();
        }

        public ActionResult Domestic()
        {
            return View();
        }

        //public ActionResult Domestic(string place, string daygo, string dayleave, int people, Tour_Inside tour_Inside)
        //{
        //    var data = db.Tour_Inside.Where(s => s.Day_go == daygo && s.Day_leave == dayleave && s.Place_go == place && s.Numberofpeople <= people );
        //    return View();
        //}
    }
}