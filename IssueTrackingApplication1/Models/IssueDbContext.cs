using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IssueTrackingApplication1.Models
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext() : base("IssueConn") { }
        public DbSet<AdminRegistration> AdminDetails { get; set; }
        public DbSet<TeamHead> RegisterTeamHeads { get; set; }
        public DbSet<RegisterDev> RegisterDevelopers { get; set; }
        public DbSet<Users> AllUsers { get; set; }
    }
}