using FinalHealthTourism.Models;
using System.Collections.Generic;

namespace FinalHealthTourism.ViewModels
{
    public class DoctorUpdateViewModel
    {
        public Doctor Doctor { get; set; }
        public List<HospitalAdmin> HospitalAdmins { get; set; }
    }
}