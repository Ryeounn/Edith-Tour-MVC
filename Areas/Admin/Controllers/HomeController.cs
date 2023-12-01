using EdithTour.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EdithTour.Areas.Admin;

namespace EdithTour.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private EdithTourEntities db = new EdithTourEntities();
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login","Account", new {area = ""});
        }

        public ActionResult Users(string search = " ")
        {
            List<Customer> customers = db.Customers.Where(row => row.Name.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(customers);
        }

        public ActionResult Edit(int id) {
            Customer cus = db.Customers.Where(row => row.ID_customer == id).FirstOrDefault();
            return View(cus);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer, HttpPostedFileBase imageFiles)
        {
            Customer customeredit = db.Customers.Where(row => row.ID_customer == customer.ID_customer).FirstOrDefault();
            if(customeredit != null)
            {
                customeredit.Name =  customer.Name;
                customeredit.Email = customer.Email;
                customeredit.Phone = customer.Phone;
                customeredit.Birthday = customer.Birthday;
                customeredit.Address = customer.Address;
                string filename = customeredit.Username + ".jpg";
                string path = Path.Combine(Server.MapPath("~/Images/Users"), filename);
                imageFiles.SaveAs(path);
                customeredit.Avatar = filename;
                db.SaveChanges();
                return View("Users");
            }
            else
            {
                return View("Edit");
            }
            
        }

        public ActionResult Delete(int id)
        {
            Customer cus = db.Customers.Where(row => row.ID_customer == id).FirstOrDefault();
            return View(cus);
        }

        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            Customer cus = db.Customers.Where(row => row.ID_customer == id).FirstOrDefault();
            db.Customers.Remove(cus);
            db.SaveChanges();
            return RedirectToAction("Users");
        }

        public ActionResult Information()
        {
            var myUser = Session["UsernameAd"].ToString();
            var ad = db.Administrators.Where(row => row.Username == myUser).FirstOrDefault();
            return View(ad);
        }

        [HttpPost]
        public ActionResult Information(Administrator administrator, HttpPostedFileBase imageFiles)
        {
            var myUser = Session["UsernameAd"].ToString();
            Administrator administratoredit = db.Administrators.Where(row => row.Username == myUser).FirstOrDefault();
            administratoredit.Name = administrator.Name;
            administratoredit.Email = administrator.Email;
            administratoredit.Phone = administrator.Phone;
            administratoredit.Birthday = administrator.Birthday;
            administratoredit.Address = administrator.Address;
            string filename = administratoredit.Username + ".jpg";
            string path = Path.Combine(Server.MapPath("~/Images/Admin"), filename);
            imageFiles.SaveAs(path);
            administratoredit.Avatar = filename;
            db.SaveChanges();
            return View("Index");
        }

    }
}