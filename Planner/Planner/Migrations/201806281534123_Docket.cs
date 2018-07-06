namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Docket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dockets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Activites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Docket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dockets", t => t.Docket_Id)
                .Index(t => t.Docket_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activites", "Docket_Id", "dbo.Dockets");
            DropIndex("dbo.Activites", new[] { "Docket_Id" });
            DropTable("dbo.Activites");
            DropTable("dbo.Dockets");
        }
    }
}
