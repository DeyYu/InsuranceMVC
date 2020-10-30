using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceProject.ViewModel;
using InsuranceProject.Models;
using System.Text;
using System.Data.Entity;

namespace InsuranceProject.Controllers
{
    public class UserController : Controller
    {
        private DBEntities1 db = new DBEntities1();
        //Allows users to register and encrypts password
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(ClientModel CM)
        {
            int sx = db.Clients.Where(x => x.UserName == CM.UserName).Count();

            if (ModelState.IsValid && sx == 0)
            {
                Client C = new Client();
                            
                C.Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(CM.Password)));
                C.FirstName = CM.FirstName;
                C.LastName = CM.LastName;
                C.UserName = CM.UserName;
                
                db.Clients.Add(C);
                db.SaveChanges();
                TempData["Message"] = "Registration Complete Successfully!";
                return RedirectToAction("Login");
                
            }
            else 
            {
                ViewBag.msg = "Username already exists!";
                return View(CM);
            }
        }

        //Allows users to login, checks for matching username and password
        //Also checks if the user logging in is a client or admin and sends them to the corresponding homepages
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ClientModel CM)
        {
            CM.Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(CM.Password)));

            int sx = db.Clients.Where(x => x.UserName == CM.UserName && x.Password == CM.Password).Count();

            if (sx == 0)
            {
                ViewBag.msg = "Username or Password was incorrect.";
                return View("Login");
            }
            else
            {
                var User = db.Clients.Where(x => x.UserName == CM.UserName && x.Password == CM.Password).FirstOrDefault();
                
                Session["UserID"] = User.ClientId;
                Session["UserName"] = User.UserName;
                Session["FirstName"] = User.FirstName;
                Session["LastName"] = User.LastName;
                if(User.ClientId == 5)
                {
                    return RedirectToAction("AdminHome", "Admin");
                }
                else
                {
                    return RedirectToAction("ClientHome", "User");
                }
            }
        }

        //Users Homepage and automatically displays user details
        public ActionResult ClientHome()
        {
            Client c = db.Clients.Find(Convert.ToInt32(Session["UserID"]));

            ClientModel cm = new ClientModel();

            cm.FirstName = c.FirstName;
            cm.LastName = c.LastName;
            cm.UserName = c.UserName;

            return View(cm);
        }

        //Allows users to edit their own details
        //Decrypts password and recrypts after edits have been made
        public ActionResult EditDetails()
        {
            Client c = db.Clients.Find(Convert.ToInt32(Session["UserID"]));

            ClientModel uvedit = new ClientModel();

            uvedit.FirstName = c.FirstName;
            uvedit.LastName = c.LastName;
            uvedit.UserName = c.UserName;
            uvedit.Password = c.Password;
            return View(uvedit);
        }
        [HttpPost]
        public ActionResult EditDetails(ClientModel CM)
        {
            if (ModelState.IsValid)
            {
                // Created a New User 
                Client c = new Client();
                c.ClientId = Convert.ToInt32(Session["UserID"]);
                c.Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(CM.Password)));
                c.FirstName = CM.FirstName;
                c.LastName = CM.LastName;
                c.UserName = CM.UserName;
                c.Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(CM.Password)));
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Your changes have been saved!";
                return RedirectToAction("ClientHome");
            }
            else
            {
                ViewBag.msg = "UserName is already exsting !";
                return View(CM);
            }
        }

        //A view which the user picks what type of vehicle to register
        //Seperated from registration as users may have more than one vehicle
        public ActionResult RegVehicle()
        {
            return View();
        }

        //Allows Users to register a Car, automatically takes Client ID
        public ActionResult RegCar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegCar(RegCarModel RCM)
        {
            if(ModelState.IsValid)
            {
                Car C = new Car();

                C.ModeOfUse = RCM.ModeOfUse;
                C.RegPlate = RCM.RegPlate;
                C.CarValue = RCM.CarValue;
                C.ClientId = Convert.ToInt32(Session["UserID"]);

                db.Cars.Add(C);
                db.SaveChanges();

                TempData["Message"] = "Car registration submitted successfully, Please wait for approval!";
                return RedirectToAction("ClientHome");
            }
            else
            {
                ViewBag.Msg="Could not Register Car";
                return View(RCM);
            }
        }

        //Allows Users to register a Motorcycle, automatically takes Client ID
        public ActionResult RegBike()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegBike(RegBikeModel RBM)
        {
            if (ModelState.IsValid)
            {
                Motorbike MB = new Motorbike();

                MB.ModeOfUse = RBM.ModeOfUse;
                MB.MotorRegPlate = RBM.MotorRegPlate;
                MB.MotorValue = RBM.MotorValue;
                MB.ClientId = Convert.ToInt32(Session["UserID"]);

                db.Motorbikes.Add(MB);
                db.SaveChanges();

                TempData["Message"] = "Motorbike registration submitted successfully, Please wait for approval!";
                return RedirectToAction("ClientHome");
            }
            else
            {
                ViewBag.Msg = "Could not register Motorbike";
                return View(RBM);
            }
        }

        //Automatically takes Client ID and sends info to Claims Table
        public ActionResult Claim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Claim(ClaimModel CM)
        {
            Claim C = new Claim();
            C.ClientId = Convert.ToInt32(Session["UserID"]);
            C.Nature = CM.Nature;
            C.Location = CM.Location;
            C.Date = CM.Date;
            C.LicensePlate = CM.LicensePlate;
            db.Claims.Add(C);
            db.SaveChanges();

            TempData["Message"] = "Your claim has been sent";
            return RedirectToAction("ClientHome");
        }

        //Logs out the User
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}