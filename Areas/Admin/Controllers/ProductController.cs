using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdithTour.Areas.Admin.Controllers
{
    public class ProductController : Controller
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
    }
}