namespace FinalHealthTourism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHospitalAssociatedToDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "HospitalAssociated", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "HospitalAssociated");
        }
    }
}
