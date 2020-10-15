using FinalHealthTourism.Models;
using System.Collections.Generic;

namespace FinalHealthTourism.ViewModels
{
    public class AppointmentViewModel
    {
        public List<Appointment> Appointments { get; set; }
        public List<Patient> Patients { get; set; }
    }
}