using FinalHealthTourism.Models;

namespace FinalHealthTourism.ViewModels
{
    public class ShowTreatmentRecordViewModel
    {
        public TreatmentRecord TreatmentRecord { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}