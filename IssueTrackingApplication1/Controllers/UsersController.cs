using IssueTrackingApplication1.Models;
using IssueTrackingApplication1.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTrackingApplication1.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Inbox(string Id)
        {
            {
                if (Id == "" || Id == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                UsersInfo usersInfo = null;
                Utils utils = new Utils();
                try
                {
                    Id = Id.Trim().Replace(" ", "+");
                    usersInfo = JsonConvert.DeserializeObject<UsersInfo>(utils.DecryptStringAES(Id));
                    if (usersInfo == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index", "Home");
                }

                Session["users"] = usersInfo;
            }
                return View();
        }

        public ActionResult ViewIssue()
        {
            var User = Session["users"] as UsersInfo;
            if (User != null)
            {
                using (IssueDbContext db = new IssueDbContext())
                {
                    var result = db.RegisterTickets.ToList();
                    if (result != null)
                    {
                        result.Reverse();
                        return View(result);
                    }
                }
            }

            return RedirectToAction("Index", "AdminProfile");
            return View();
        }

        public ActionResult CreateTicket()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateTicket(IssueInfo issueInfo, HttpPostedFileBase img)
        {
            issueInfo.TicketId = Guid.NewGuid().ToString().Substring(0, 8);
            var UserData = Session["users"] as UsersInfo;
            issueInfo.Email = UserData.Email;
            issueInfo.image = img != null ? img.FileName : "";

            
                if (img != null)
                {
                    using (IssueDbContext db = new IssueDbContext())
                    {

                        string path = Path.Combine(Server.MapPath("~/Content/photos"), Path.GetFileName(img.FileName));
                        img.SaveAs(path);
                        var result = db.RegisterTickets.Add(issueInfo);
                        if (result != null)
                        {
                            db.SaveChanges();
                        }
                        return View();
                    }
                    ViewBag.Message = "TicketId:" + " " + issueInfo.TicketId;
                    
                }
            
           
            return View();
        }

        public ActionResult ManageAccount()
        {
            return View();
        }

      /*  [HttpPost]
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
        }*/

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