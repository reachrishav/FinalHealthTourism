using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalHealthTourism.Models
{
    public class TreatmentRecord
    {

        [Key]
        [DisplayName("Patient Id")]
        public string P_Id { get; set; }

        public string PatientId { get; set; }

        public string DoctorId { get; set; }

        [DisplayName("Diagnosis Details")]
        public string DiagnosisDetails { get; set; }

        [DisplayName("Treatment Planned")]
        public string TreatmentPlanned { get; set; }

        [DisplayName("Medicines Prescribed")]
        public string MedicinesPrescribed { get; set; }

        [DisplayName("Revisit Date")]
        public DateTime? RevisitDate { get; set; }

    }
}