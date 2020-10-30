using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceProject.ViewModel;
using InsuranceProject.Models;

namespace InsuranceProject.Controllers
{
    public class HomeController : Controller
    {
        private DBEntities1 db = new DBEntities1();

        //Web Application Homepage
        public ActionResult Index()
        {
            return View();
        }

        //A view about the company 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //A view about the services provided
        public ActionResult Services()
        {
            return View();
        }

        //A view that allows users to send messages directly to the table "Contact"
        //No login is required
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModel M)
        {
            if (ModelState.IsValid)
            {
                Contact c = new Contact();
                c.First_Name = M.First_Name;
                c.Last_Name = M.Last_Name;
                c.Phone_Number = M.Phone_Number;
                c.Email_Address = M.Email_Address;
                c.Message = M.Message;

                if (ModelState.IsValid)
                {
                    db.Contacts.Add(c);
                    db.SaveChanges();
                    ViewBag.msg = "Your Message has been sent";
                    return View(M);
                }
            }
            return View(M);
        }

        public ActionResult Quote()
        {
            return View();
        }
    }
}