using EdithTour.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            return View();
        }

        [HttpPost]
        public ActionResult Inside(Tour_Inside tour_Inside)
        {
            var place = Session["Place"].ToString();
            var day = Session["Daystart"].ToString();
            var leave = Session["Dayleave"].ToString();
            var data = db.Tour_Inside.Where(s=>s.Place_go == place && s.Day_go == day && s.Day_leave == leave);
            if(data != null)
            {
                List<Tour_Inside> tours = data.ToList();
                return View(tours);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Outside()
        {
            return View();
        }

        public ActionResult Foreign() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Foreign(string placestart, string placego, string daygo, string dayleave, int people, Tour_Outside tour_Outside)
        {
            var data = db.Tour_Outside.Where(s => s.Place_go == placestart && s.Place_leave == placego && s.Day_go == daygo && s.Day_leave == dayleave && s.Numberofpeople <= people);
            if(data != null)
            {
                Session["PlaceStartF"] = placestart;
                Session["PlaceGoF"] = placego;
                Session["DaystartF"] = daygo;
                Session["DayleaveF"] = dayleave;
                Session["PeopleF"] = people;
                return View(data);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Domestic()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Domestic(string place, string daygo, string dayleave, int people, Tour_Inside tour_Inside)
        {
            var data = db.Tour_Inside.Where(s => s.Day_go == daygo && s.Day_leave == dayleave && s.Place_go == place && s.Numberofpeople <= people);
            if(data != null)
            {
                Session["Place"] = place;
                Session["Daystart"] = daygo;
                Session["Dayleave"] = dayleave;
                Session["People"] = people;
                return View(data);
            }
            else
            {
                return View();
            }
        }

    }
}