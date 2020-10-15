namespace FinalHealthTourism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TreatmentRecords", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.TreatmentRecords", "PatientId", "dbo.Patients");
            DropIndex("dbo.TreatmentRecords", new[] { "PatientId" });
            DropIndex("dbo.TreatmentRecords", new[] { "DoctorId" });
            AlterColumn("dbo.TreatmentRecords", "PatientId", c => c.String());
            AlterColumn("dbo.TreatmentRecords", "DoctorId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TreatmentRecords", "DoctorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.TreatmentRecords", "PatientId", c => c.String(maxLength: 128));
            CreateIndex("dbo.TreatmentRecords", "DoctorId");
            CreateIndex("dbo.TreatmentRecords", "PatientId");
            AddForeignKey("dbo.TreatmentRecords", "PatientId", "dbo.Patients", "Id");
            AddForeignKey("dbo.TreatmentRecords", "DoctorId", "dbo.Doctors", "Id");
        }
    }
}
