using IssueTrackingApplication1.Models;
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
        public ActionResult Index(string username, string password)
        {
            if (ModelState.IsValid)
            {
                using (IssueDbContext db = new IssueDbContext()) 
                {
                    var result = db.RegisterUsers.SingleOrDefault(u => u.Username == username && u.Password == password);
                    if(result == null)
                    {
                        ViewBag.Message = "Invalid username or Password";
                        return View();
                    }
                }
            }
            return RedirectToAction("Index", "Users");
        }

        public ActionResult RegisterNow()
        {
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