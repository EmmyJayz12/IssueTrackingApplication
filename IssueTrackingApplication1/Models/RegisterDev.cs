using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IssueTrackingApplication1.Models
{
    public class RegisterDev
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }


        public string Gender { get; set; }

        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "EmployeeId is Required")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Your Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; }

        [Compare("Password", ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [SqlDefaultValue(Defaultvalue = "getdate()")]
        public DateTime DataRegistered { get; set; } = DateTime.Now;
    }
}