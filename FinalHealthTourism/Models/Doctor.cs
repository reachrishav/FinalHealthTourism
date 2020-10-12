using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalHealthTourism.Models
{
    public class Doctor
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Contact Number")]
        [RegularExpression(@"[6789]{1}[0-9]{9}", ErrorMessage = "Enter in correct format")]
        public string ContactNumber { get; set; }

        [DisplayName("Email Id")]
        [RegularExpression(@"[a-zA-Z0-9]{3,}[@][a-zA-Z0-9]{3,}[.][a-zA-Z0-9]{3,}", ErrorMessage = "Enter in correct format")]
        public string Email { get; set; }

        [Key]
        public string Id { get; set; }

        [RegularExpression(@"[a-zA-Z0-9@#@!%^&*]{5,}", ErrorMessage = "Atleast 5 chars")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Retype Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password did not match")]
        public string RetypePassword { get; set; }


        public DateTime FromDateTimeAvailable { get; set; }

        public DateTime ToDateTimeAvailable { get; set; }

        public string Speciality { get; set; }



    }
}