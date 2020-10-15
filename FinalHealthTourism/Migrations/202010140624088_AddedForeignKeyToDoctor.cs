namespace FinalHealthTourism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyToDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "HospitalAdminId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Doctors", "HospitalAdminId");
            AddForeignKey("dbo.Doctors", "HospitalAdminId", "dbo.HospitalAdmins", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "HospitalAdminId", "dbo.HospitalAdmins");
            DropIndex("dbo.Doctors", new[] { "HospitalAdminId" });
            DropColumn("dbo.Doctors", "HospitalAdminId");
        }
    }
}
