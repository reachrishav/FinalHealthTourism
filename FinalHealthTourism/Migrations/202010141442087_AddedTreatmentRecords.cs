namespace FinalHealthTourism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTreatmentRecords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreatmentRecords",
                c => new
                    {
                        P_Id = c.String(nullable: false, maxLength: 128),
                        PatientId = c.String(maxLength: 128),
                        DoctorId = c.String(maxLength: 128),
                        DiagnosisDetails = c.String(),
                        TreatmentPlanned = c.String(),
                        MedicinesPrescribed = c.String(),
                    })
                .PrimaryKey(t => t.P_Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TreatmentRecords", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.TreatmentRecords", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.TreatmentRecords", new[] { "DoctorId" });
            DropIndex("dbo.TreatmentRecords", new[] { "PatientId" });
            DropTable("dbo.TreatmentRecords");
        }
    }
}
