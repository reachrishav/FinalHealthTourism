using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalHealthTourism.Models
{
    public class Doctor
    {
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        [RegularExpression(@"[6789]{1}[0-9]{9}", ErrorMessage = "Enter in correct format")]
        public string ContactNumber { get; set; }

        [Required]
        [DisplayName("Email Id")]
        [RegularExpression(@"[a-zA-Z0-9]{3,}[@][a-zA-Z0-9]{3,}[.][a-zA-Z0-9]{3,}", ErrorMessage = "Enter in correct format")]
        public string Email { get; set; }

        [Required]
        [Key]
        public string Id { get; set; }

        [RegularExpression(@"[a-zA-Z0-9@#@!%^&*]{5,}", ErrorMessage = "Atleast 5 chars")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        /*[DisplayName("Retype Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password did not match")]
        public string RetypePassword { get; set; }
        */

        [DataType(DataType.DateTime)]
        [DisplayName("Available From")]
        public DateTime FromDateTimeAvailable { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Available To")]
        public DateTime ToDateTimeAvailable { get; set; }

        public string Speciality { get; set; }

        [DisplayName("Hospital Associated")]
        public string HospitalAssociated { get; set; }

        public string HospitalAdminId { get; set; }

        public HospitalAdmin HospitalAdmin { get; set; }


    }
}