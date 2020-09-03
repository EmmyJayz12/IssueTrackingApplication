using IssueTrackingApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTrackingApplication1.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateIssue()
        {
            return View();
        }

        public ActionResult AssignLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AssignLogin(string username, string password)
        {
            if (ModelState.IsValid)
            {
                using (IssueDbContext db = new IssueDbContext())
                {
                    var result = db.RegisterTeamHeads.SingleOrDefault(u => u.Username == username && u.Password == password);
                    if(result == null)
                    {
                        ViewBag.Message = "Wrong username or password";
                        ModelState.Clear();
                        return View();
                    }
                }
                ModelState.Clear();
            }
            return RedirectToAction("Index", "DevUsers");
        }

        public ActionResult ResolveLogin()
        {

            return View();
        }

        public ActionResult AdminLogin()
        {

            return View();
        }
    }
}