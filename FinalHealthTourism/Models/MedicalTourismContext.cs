using System.Data.Entity;

namespace FinalHealthTourism.Models
{
    public class MedicalTourismContext : DbContext
    {
        public MedicalTourismContext() : base("Name=Connect")
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<HospitalAdmin> HospitalAdmins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<TreatmentRecord> TreatmentRecords { get; set; }
    }
}