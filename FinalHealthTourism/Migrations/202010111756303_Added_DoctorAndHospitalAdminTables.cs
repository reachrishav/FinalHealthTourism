namespace FinalHealthTourism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_DoctorAndHospitalAdminTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(),
                        ContactNumber = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        FromDateTimeAvailable = c.DateTime(nullable: false),
                        ToDateTimeAvailable = c.DateTime(nullable: false),
                        Speciality = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HospitalAdmins",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        HospitalName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Certification = c.String(),
                        SuccessfulOperations = c.Int(nullable: false),
                        Achievements = c.String(),
                        Specialities = c.String(),
                        FacilitiesAvailable = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HospitalAdmins");
            DropTable("dbo.Doctors");
        }
    }
}
