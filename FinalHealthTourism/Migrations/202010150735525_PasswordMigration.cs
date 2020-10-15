namespace FinalHealthTourism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "Password", c => c.String(nullable: false));
        }
    }
}
