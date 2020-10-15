namespace FinalHealthTourism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRevisitColumnToTreatment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TreatmentRecords", "RevisitDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TreatmentRecords", "RevisitDate");
        }
    }
}
