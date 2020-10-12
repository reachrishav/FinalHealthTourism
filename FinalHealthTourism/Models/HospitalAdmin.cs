using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalHealthTourism.Models
{
    public class HospitalAdmin
    {
        [Key]
        public string Id { get; set; }

        [DisplayName("Hospital Name")]
        public string HospitalName { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        public int ZipCode { get; set; }

        [DisplayName("Certification")]
        public string Certification { get; set; }

        [DisplayName("Successful Operations")]
        public int SuccessfulOperations { get; set; }

        [DisplayName("Achievements")]
        public string Achievements { get; set; }

        [DisplayName("Specialities")]
        public string Specialities { get; set; }

        [DisplayName("Facilities Available")]
        public string FacilitiesAvailable { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsApproved { get; set; }    

    }
}