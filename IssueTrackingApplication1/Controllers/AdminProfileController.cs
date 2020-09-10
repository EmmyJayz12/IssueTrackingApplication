using IssueTrackingApplication1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using IssueTrackingApplication1.Utility;

namespace IssueTrackingApplication1.Controllers
{
    public class AdminProfileController : Controller
    {
        // GET: AdminProfile
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
            AdminInfo adminInfo = null;
            Utils utils = new Utils();
            try
            {
                Id = Id.Trim().Replace(" ", "+");
                adminInfo = JsonConvert.DeserializeObject<AdminInfo>(utils.DecryptStringAES(Id));
                if (adminInfo == null)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }

            Session["admin"] = adminInfo;
            return View();
        }

        public ActionResult ViewIssue()
        {  
                var AdminUser = Session["admin"] as AdminInfo;
                if (AdminUser != null)
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
                }
            
            return RedirectToAction("Index", "AdminProfile");
        }

        [HttpPost]
        public ActionResult EditTicket(IssueInfo info)
        {
            
                using (IssueDbContext db = new IssueDbContext())
                {
                    var result = db.RegisterTickets.SingleOrDefault(u => u.UserId == info.UserId);
                    if(result != null)
                    {
                        result.AssignTo = info.AssignTo;
                        result.Status = info.Status;
                        
                    if (info.Status.ToUpper() == "CLOSED")
                    {
                        result.ClosedDate = DateTime.Now.ToString();
                        result.ClosedBy = info.ClosedBy;
                    }
                    else
                    {
                        result.ClosedDate = "Pending";
                        result.ClosedBy = "Pending";
                    }
                       
                        db.SaveChanges();
                    }
                }
            
            return RedirectToAction("ViewIssue");
        }

        public ActionResult EditTicket()
        {
            if(Session["user2"] == null)
            {
                return RedirectToAction("Inbox");
            }

            return View();
        }

        public ActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Inbox", "AdminProfile");
            }

            using (IssueDbContext db = new IssueDbContext())
            {
                var result = db.RegisterTickets.SingleOrDefault(u => u.UserId == id);
                if (result == null)
                {
                    return RedirectToAction("Inbox");
                }

                Session["user2"] = result;

            }
            return RedirectToAction("EditTicket");
        }

        
        public ActionResult ManageAccount()
        {
            return View();
        }

      /*  [HttpPost]
        public ActionResult RegisterTeamHead(TeamHead team)
        {
            if (ModelState.IsValid)
            {
                if (team.Password == team.ConfirmPassword)
                {
                    using (IssueDbContext db = new IssueDbContext())
                    {
                        var result = db.RegisterTeamHeads.SingleOrDefault((u => u.Email == team.Email && u.Password == team.Password));
                        if (result == null)
                        {
                            db.RegisterTeamHeads.Add(team);
                            db.SaveChanges();

                        }
                        ViewBag.Message = "record already exist";
                    }
                }
                ModelState.Clear();

            }
            return View();
        }*/
          

        public ActionResult RegisterDev()
        {
            return View();
        }

      /*  [HttpPost]
        public ActionResult RegisterDev(RegisterDev reg)
        {
            if (ModelState.IsValid)
            {
                if (reg.Password == reg.ConfirmPassword)
                {
                    using (IssueDbContext db = new IssueDbContext())
                    {
                        var result = db.RegisterTeamHeads.SingleOrDefault((u => u.Email == reg.Email && u.Password == reg.Password));
                        if (result == null)
                        {
                            db.RegisterDevelopers.Add(reg);
                            db.SaveChanges();
                        }
                        ViewBag.Message = "record already exist";
                    }
                }
                ViewBag.Message = "Registered Successful";
                ModelState.Clear();
            }

            return View();
        } */

        public ActionResult RegisterUsers()
        {
            return View();
        }

       /* [HttpPost]
        public ActionResult RegisterUsers(IssueInfo user)
        {
            if (ModelState.IsValid)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    using (IssueDbContext db = new IssueDbContext())
                    {
                        var result = db.RegisterTeamHeads.SingleOrDefault((u => u.Email == user.Email && u.Password == user.Password));
                        if (result == null)
                        {
                            db.RegisterUsers.Add(user);
                            db.SaveChanges();
                        }
                        ViewBag.Message = "record already exist";
                    }
                }
                ViewBag.Message = "Registered Successful";
                ModelState.Clear();
            }
            return View();
        } /*S

       /* [HttpGet]
        [Route("AdminProfile/Inbox?Id={ResponseCode?}")]
        public ActionResult Index(string ResponseCode)
        {
           
                if (ResponseCode == "" || ResponseCode == null)
                {
                return View();
                }

            AdminInfo adminInfo = DecryptStringAES(ResponseCode);
            Session["admin"] = adminInfo;
            return RedirectToAction("Inbox");
        }*/
    }
}