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

        public ActionResult ResolveLogin()
        {

            return View();
        }
    }
}