﻿using EdithTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using EdithTour.Areas.Admin;
using System.Web.Mvc;

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
        public ActionResult Login(string username, string password, Customer customer, Admin admin)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data_cus = db.Customers.Where(s => s.Username == customer.Username && s.Password.Equals(f_password));
                var data_ad = db.Admins.Where(s => s.Username == admin.Username && s.Password.Equals(f_password));
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
                    Session["Name"] = data_ad.FirstOrDefault().Name;
                    Session["Email"] = data_ad.FirstOrDefault().Email;
                    Session["ID_admin"] = data_ad.FirstOrDefault().ID_admin;
                    Session["Phone"] = data_ad.FirstOrDefault().Phone;
                    Session["Address"] = data_ad.FirstOrDefault().Address;
                    Session["Birthday"] = data_ad.FirstOrDefault().Birthday;
                    Session["Avatar"] = data_ad.FirstOrDefault().Avatar;
                    Session["Password"] = f_password;
                    Session["Username"] = data_ad.FirstOrDefault().Username;
                    return View("~/Areas/Admin/Views/HomeAdmin/Index.cshtml");
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
                //var check_ad = db.Admins.FirstOrDefault(s => s.Username == customer.Username);
                if (check == null)
                {
                    customer.Password = GetMD5(customer.Password);
                    //customer.Name = customer.Name;
                    //customer.Email = customer.Email;
                    //customer.Phone = customer.Phone;
                    //customer.Address = customer.Address;
                    //customer.Birthday = customer.Birthday;
                    //customer.Username = customer.Username;
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                    
                }
                //else if (check_ad == null)
                //{
                //    admin.Password = GetMD5(admin.Password);
                //    admin.Name = admin.Name;
                //    admin.Email = admin.Email;
                //    admin.Phone = admin.Phone;
                //    admin.Address = admin.Address;
                //    admin.Birthday = admin.Birthday;
                //    admin.Avatar = admin.Avatar;
                //    db.Admins.Add(admin);
                //    return View("~/Areas/Admin/Views/HomeAdmin/Index.cshtml");

                //}
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
    }
}