using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace Capstone_.Controllers
{
    public class HomeController : TwilioController
    {
        //GET /home/index
        public ActionResult Index()
        {
            return View();
        }

        //GET /home/about
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
        //[HttpPost]
        //public ActionResult Contact(string message)
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        public ActionResult Twilio(string name, string eventName)
        {
            var response = new VoiceResponse();
            response.Say(name + " has invited you to" + eventName);
            return TwiML(response);
        }
    }
}