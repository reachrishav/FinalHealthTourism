namespace FinalHealthTourism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredToPasswordAgain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "Password", c => c.String());
        }
    }
}
