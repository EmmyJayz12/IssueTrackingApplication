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
        public DbSet<IssueInfo> RegisterTickets{ get; set; }
    }
}