namespace FinalHealthTourism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredAttributesToDoctorAndHospital : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "ContactNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.HospitalAdmins", "HospitalName", c => c.String(nullable: false));
            AlterColumn("dbo.HospitalAdmins", "City", c => c.String(nullable: false));
            AlterColumn("dbo.HospitalAdmins", "State", c => c.String(nullable: false));
            AlterColumn("dbo.HospitalAdmins", "Certification", c => c.String(nullable: false));
            AlterColumn("dbo.HospitalAdmins", "Achievements", c => c.String(nullable: false));
            AlterColumn("dbo.HospitalAdmins", "Specialities", c => c.String(nullable: false));
            AlterColumn("dbo.HospitalAdmins", "FacilitiesAvailable", c => c.String(nullable: false));
            AlterColumn("dbo.HospitalAdmins", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HospitalAdmins", "Password", c => c.String());
            AlterColumn("dbo.HospitalAdmins", "FacilitiesAvailable", c => c.String());
            AlterColumn("dbo.HospitalAdmins", "Specialities", c => c.String());
            AlterColumn("dbo.HospitalAdmins", "Achievements", c => c.String());
            AlterColumn("dbo.HospitalAdmins", "Certification", c => c.String());
            AlterColumn("dbo.HospitalAdmins", "State", c => c.String());
            AlterColumn("dbo.HospitalAdmins", "City", c => c.String());
            AlterColumn("dbo.HospitalAdmins", "HospitalName", c => c.String());
            AlterColumn("dbo.Doctors", "Password", c => c.String());
            AlterColumn("dbo.Doctors", "Email", c => c.String());
            AlterColumn("dbo.Doctors", "ContactNumber", c => c.String());
            AlterColumn("dbo.Doctors", "Gender", c => c.String());
            AlterColumn("dbo.Doctors", "LastName", c => c.String());
            AlterColumn("dbo.Doctors", "FirstName", c => c.String());
        }
    }
}
