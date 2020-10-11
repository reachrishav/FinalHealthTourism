namespace FinalHealthTourism.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedAnnotations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
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
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
