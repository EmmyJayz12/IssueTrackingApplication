using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTrackingApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterNow()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}