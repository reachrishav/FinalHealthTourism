using System;
using System.ComponentModel.DataAnnotations;

namespace FinalHealthTourism.Models
{
    public class Appointment
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [Required]
        public string PatientId { get; set; }

        public Patient Patient { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public bool AppointmentApproved { get; set; }
    }
}