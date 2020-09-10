using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IssueTrackingApplication1.Models
{
    public class IssueInfo
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Your Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Priority is Required")]
        public string Priority { get; set; }

        [Required(ErrorMessage = "Status is Required")]
        public string Status { get; set; } = "PENDING";

        public string ClosedBy { get; set; } = "PENDING";

        [Required(ErrorMessage = "Assign to is Required")]
        public string AssignTo { get; set; } = "PENDING";

        public string ClosedDate { get; set; } = "PENDING";

        [Required(ErrorMessage = "Issue Type is Required")]
        public string IssueType { get; set; }

        public string TicketId { get; set; }

        [Required(ErrorMessage = "File is Required")]
        public string image { get; set; }

        [Required(ErrorMessage = "Your Description is Required")]
        public string Description { get; set; }

        [SqlDefaultValue(Defaultvalue = "getdate()")]
        public DateTime DataRegistered { get; set; } = DateTime.Now;
    }
}