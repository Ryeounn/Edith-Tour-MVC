using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdithTour.Areas.Admin.Controllers
{
    public class AddController : Controller
    {
        // GET: Admin/Product
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Outside()
        {
            return View();
        }

        public ActionResult Inside()
        {
            return View();
        }

        public ActionResult Trending()
        {
            return View();
        }

        public ActionResult Customer()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Restaurant()
        {
            return View();
        }

        public ActionResult Hotel()
        {
            return View();
        }
    }
}