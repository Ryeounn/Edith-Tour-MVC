using EdithTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using EdithTour.Areas.Admin;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using System.Web.UI.WebControls;
using System.IO;

namespace EdithTour.Controllers
{
    public class AccountController : Controller
    {
        public EdithTourEntities db = new EdithTourEntities();
        // GET: Account
        public ActionResult Index()
        {
            if (Session["ID_customer"] != null)
            {
                return View("Index", "Home");
            }
            else if (Session["ID_admin"] != null)
            {
                return View("Index", "HomeAdmin");
            }
            return Index();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password, Customer customer, Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data_cus = db.Customers.Where(s => s.Username == customer.Username && s.Password.Equals(f_password));
                var data_ad = db.Administrators.Where(s => s.Username == administrator.Username && s.Password.Equals(f_password));
                if (data_cus.Count() > 0)
                {
                    //add session
                    Session["Name"] = data_cus.FirstOrDefault().Name;
                    Session["Email"] = data_cus.FirstOrDefault().Email;
                    Session["ID_Customer"] = data_cus.FirstOrDefault().ID_customer;
                    Session["Phone"] = data_cus.FirstOrDefault().Phone;
                    Session["Address"] = data_cus.FirstOrDefault().Address;
                    Session["Birthday"] = data_cus.FirstOrDefault().Birthday;
                    Session["Avatar"] = data_cus.FirstOrDefault().Avatar;
                    Session["Password"] = f_password;
                    Session["Username"] = data_cus.FirstOrDefault().Username;
                    return RedirectToAction("Index", "Home");
                }
                else if (data_ad.Count() > 0)
                {
                    //add session
                    Session["NameAd"] = data_ad.FirstOrDefault().Name;
                    Session["EmailAd"] = data_ad.FirstOrDefault().Email;
                    Session["ID_admin"] = data_ad.FirstOrDefault().ID_admin;
                    Session["PhoneAd"] = data_ad.FirstOrDefault().Phone;
                    Session["AddressAd"] = data_ad.FirstOrDefault().Address;
                    Session["BirthdayAd"] = data_ad.FirstOrDefault().Birthday;
                    Session["AvatarAd"] = data_ad.FirstOrDefault().Avatar;
                    Session["PasswordAd"] = f_password;
                    Session["UsernameAd"] = data_ad.FirstOrDefault().Username;
                    //return View("~/Areas/Admin/Views/HomeAdmin/Index.cshtml");
                    return RedirectToAction("Index", "Home", new {area="Admin"});
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();

        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var check = db.Customers.FirstOrDefault(s => s.Username == customer.Username);
                if (check == null)
                {
                    customer.Password = GetMD5(customer.Password);
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                    
                }
                else
                {
                    ViewBag.error = "Username already exists";
                    return View();
                }
            }
            return View();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public ActionResult Information()
        {
            return View();
        }

        public ActionResult General()
        {
            var user = Session["Username"].ToString();
            Customer customer = db.Customers.Where(s => s.Username == user).FirstOrDefault();
            return View(customer);
        }

        [HttpPost]
        public ActionResult General(Customer customer, HttpPostedFileBase imageFiles)
        {
            if (ModelState.IsValid)
            {
                var user = Session["Username"].ToString();
                var data = db.Customers.FirstOrDefault(s => s.Username == user);
                if (data != null)
                {
                    Customer customeredit = db.Customers.Where(row => row.Username == user).FirstOrDefault();
                    customeredit.Name = customer.Name;
                    customeredit.Email = customer.Email;
                    customeredit.Address = customer.Address;
                    customeredit.Birthday = customer.Birthday;
                    customeredit.Phone = customer.Phone;
                    string filename = customeredit.Username + ".jpg";
                    string path = Path.Combine(Server.MapPath("~/Images/Users"), filename);
                    imageFiles.SaveAs(path);
                    customeredit.Avatar = filename;
                    db.SaveChanges();
                    return RedirectToAction("Information", "Account");
                }
                else
                {
                    return RedirectToAction("Information", "Account");
                }
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string Password, Customer customer, string New)
        {
            var user = Session["Username"].ToString();
            var Pass = GetMD5(Password);
            var NewPass = GetMD5(New);

            //var fpassword = GetMD5(Password);
            var data = db.Customers.Where(s => s.Username == user && s.Password == Pass);
            if (data != null)
            {

                var cus = db.Customers.Where(s => s.Username == user && s.Password == NewPass).FirstOrDefault();
                if (cus == null)
                {
                    var customeredit = db.Customers.FirstOrDefault(s => s.Username == user);
                    customeredit.Password = NewPass;
                    db.SaveChanges();
                    return View("Information");
                }
                else
                {
                    return RedirectToAction("Information");

                }
            }

            else
            {
                return View("Login");

            }


        }
    }
}