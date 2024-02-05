using Kutse_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kutse_App.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Kutse()
        {
            
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 10 ? "Tere hommikust" : "Tere päevast";
            ViewBag.Message = "Ootan sind oma peole! Tule kindlasti!!! Ootan sind!";
            return View();
        }
        
        public ActionResult Index()
        {
            ViewBag.Message = "Ootan sind minu peole! Palun tule!!!";
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 10 ? "Tere hommikust" : "Tere päevast";
            return View();
        }
        [HttpGet]
        public ActionResult Ankeet()
        {

            return View();
        }
        [HttpPost]
        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            if (ModelState.IsValid)
            {
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }
        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "stmp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "programmeriminevc@gmail.com";
                WebMail.Password = "123456";
                WebMail.From = "programmeriminevc@gmail.com";
                WebMail.Send("matveikulakovski@gmail.com", "Vastus kutsele", guest.Name + "vastus" + ((guest.WillAttend ?? false) ?
                    "tuleb peole" : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahjul saa kirja saada!!!";
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}