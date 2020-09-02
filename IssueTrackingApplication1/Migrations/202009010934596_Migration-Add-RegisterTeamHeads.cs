namespace IssueTrackingApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAddRegisterTeamHeads : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamHeads",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.String(),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        EmployeeId = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        DataRegistered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeamHeads");
        }
    }
}
