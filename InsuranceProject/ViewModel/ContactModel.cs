using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.ViewModel
{
    public class ContactModel
    {
        [Key]
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Please enter a phone number")]
        public int Phone_Number { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email_Address { get; set; }
        [Required(ErrorMessage = "Please enter a message")]
        public string Message { get; set; }
    }
}