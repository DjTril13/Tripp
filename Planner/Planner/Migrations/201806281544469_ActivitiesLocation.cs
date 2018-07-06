namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivitiesLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activites", "Lat", c => c.Double(nullable: false));
            AddColumn("dbo.Activites", "Lng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activites", "Lng");
            DropColumn("dbo.Activites", "Lat");
        }
    }
}
