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
    }
}