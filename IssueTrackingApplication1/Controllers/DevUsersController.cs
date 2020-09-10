using IssueTrackingApplication1.Models;
using IssueTrackingApplication1.Utility;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTrackingApplication1.Controllers
{
    public class DevUsersController : Controller
    {
        public string Id { get; private set; }

        // GET: DevUsers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inbox(string Id)
        {
            if (Id == "" || Id == null)
            {
                return RedirectToAction("Index");
            }
            DevInfo devInfo = null;
            Utils utils = new Utils();
            try
            {
                Id = Id.Trim().Replace(" ", "+");
                devInfo = JsonConvert.DeserializeObject<DevInfo>(utils.DecryptStringAES(Id));
                if (devInfo == null)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception e)
            {
                return RedirectToAction("Index");
            }

            Session["devInfo"] = devInfo;
            return View();
        }
    

        public ActionResult ViewIssue()
        {
            using (IssueDbContext db = new IssueDbContext())
            {
                
                var result = db.RegisterTickets.ToList();
                if(result != null)
                {
                    result.Reverse();
                    return View(result);
                }
            }
            return View();
        }

        public ActionResult EditTicket(string id)
        {
            if(Session["user1"] == null)
            {
                return RedirectToAction("Inbox");
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditTicket(IssueInfo info)
        {
            using (IssueDbContext db = new IssueDbContext())
            {
                var result = db.RegisterTickets.SingleOrDefault(u => u.UserId == info.UserId);
                if(result != null)
                {
                    result.Status = info.Status;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("ViewIssue");
        }

        public ActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Inbox", "DevUsers");
            }

            using (IssueDbContext db = new IssueDbContext())
            {
                var result = db.RegisterTickets.SingleOrDefault(u => u.UserId == id);
                if (result == null)
                {
                    return RedirectToAction("Inbox");
                }

                Session["user1"] = result;

            }
            return RedirectToAction("EditTicket");
        }

        public ActionResult ManageAccount()
        {
            return View();
        }
    }
}