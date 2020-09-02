using IssueTrackingApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTrackingApplication1.Controllers
{
    public class AdminProfileController : Controller
    {
        // GET: AdminProfile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminRegistration reg)
        {
            if (ModelState.IsValid)
            {
                if (reg.Password == reg.ConfirmPassword)
                {
                    using (IssueDbContext db = new IssueDbContext())
                    {
                        var result = db.AdminDetails.SingleOrDefault((u => u.Email == reg.Email && u.Password == reg.Password));
                        if (result == null)
                        {
                            db.AdminDetails.Add(reg);
                            db.SaveChanges();
                            
                        }
                        ViewBag.Message = "record already exist";
                    }
                }
                ModelState.Clear();
                
            }
            return View();
        }

        public ActionResult RegisterTeamHead()
        {    
                    
            return View();
        }

        [HttpPost]
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
        }
          

        public ActionResult RegisterDev()
        {
            return View();
        }

        [HttpPost]
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
        }

        public ActionResult RegisterUsers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUsers(Users user)
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
                            db.AllUsers.Add(user);
                            db.SaveChanges();
                        }
                        ViewBag.Message = "record already exist";
                    }
                }
                ViewBag.Message = "Registered Successful";
                ModelState.Clear();
            }
            return View();
        }
    }
}