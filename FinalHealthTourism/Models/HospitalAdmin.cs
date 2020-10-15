using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalHealthTourism.Models
{
    public class HospitalAdmin
    {

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [DisplayName("Hospital Name")]
        public string HospitalName { get; set; }

        [Required]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [DisplayName("State")]
        public string State { get; set; }

        [Required]
        [DisplayName("Zip Code")]
        public int ZipCode { get; set; }

        [Required]
        [DisplayName("Certification")]
        public string Certification { get; set; }

        [Required]
        [DisplayName("Successful Operations")]
        public int SuccessfulOperations { get; set; }

        [Required]
        [DisplayName("Achievements")]
        public string Achievements { get; set; }

        [Required]
        [DisplayName("Specialities")]
        public string Specialities { get; set; }

        [Required]
        [DisplayName("Facilities Available")]
        public string FacilitiesAvailable { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsApproved { get; set; }

    }
}