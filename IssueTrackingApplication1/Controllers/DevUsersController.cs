using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTrackingApplication1.Controllers
{
    public class DevUsersController : Controller
    {
        // GET: DevUsers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AssignIssue()
        {
            return View();
        }

        public ActionResult SentMail()
        {
            return View();
        }

        public ActionResult Draft()
        {
            return View();
        }

        public ActionResult Trash()
        {
            return View();
        }
    }
}