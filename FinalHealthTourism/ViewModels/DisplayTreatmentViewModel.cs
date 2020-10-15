using FinalHealthTourism.Models;
using System.Collections.Generic;

namespace FinalHealthTourism.ViewModels
{
    public class DisplayTreatmentViewModel
    {
        public List<TreatmentRecord> TreatmentRecords { get; set; }
        public Patient Patient { get; set; }
    }
}