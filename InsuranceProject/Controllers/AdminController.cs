using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceProject.Models;

namespace InsuranceProject.Controllers
{
    public class AdminController : Controller
    {
        private DBEntities1 db = new DBEntities1();
        // Admin Homepage
        public ActionResult AdminHome()
        {
            return View();
        }

        // Admin view all Messages
        public ActionResult Messages()
        {
            return View(db.Contacts.ToList());
        }

        // Admin view all Clients
        public ActionResult Clients()
        {
            return View(db.Clients.ToList());
        }

        // Admin view all Clients
        public ActionResult Claims()
        {
            return View(db.Claims.ToList());
        }

        // Admin search clients by id (Does not allow null input)
        public ActionResult FindClients(int? clientid)
        {
            int sx = db.Clients.Where(x => x.ClientId == clientid).Count();
            if (clientid == null)
            {
                TempData["Message"] = "This client id does not exists!";
                return RedirectToAction("Clients", "Admin");
            }
            else
            {
                return View(db.Clients.Find(clientid));
            }
        }

        // Admin search claims by id (Does not allow null input)
        public ActionResult FindClaims(int? claimid)
        {
            if (claimid == null)
            {
                TempData["Message"] = "This claim id does not exists!";
                return RedirectToAction("Claims", "Admin");
            }
            else
            {
                return View(db.Claims.Find(claimid));
            }
        }
    }
}