using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalHealthTourism.Models
{
    public class Patient
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

        [DisplayName("Gender")]
        [Required]
        public string Gender { get; set; }

        [DisplayName("Contact Number")]
        [Required]
        [RegularExpression(@"[6789]{1}[0-9]{9}", ErrorMessage = "Enter in correct format")]
        public string ContactNumber { get; set; }

        [DisplayName("Email Id")]
        [Required]
        [RegularExpression(@"[a-zA-Z0-9]{3,}[@][a-zA-Z0-9]{3,}[.][a-zA-Z0-9]{3,}", ErrorMessage = "Enter in correct format")]
        public string Email { get; set; }

        [Key]
        [Required]
        public string Id { get; set; }

        [RegularExpression(@"[a-zA-Z0-9@#@!%^&*]{5,}", ErrorMessage = "Atleast 5 chars")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        /*[DisplayName("Retype Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password did not match")]
        public string RetypePassword { get; set; }*/
    }
}