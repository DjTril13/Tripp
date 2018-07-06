namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedActivites : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT[dbo].[Activites] ON");
            Sql("INSERT INTO[dbo].[Activites] ([Id], [Title], [Docket_Id], [Lat], [Lng]) VALUES(1, N'Ipsento', 1, 41.918767, -87.68641)");
            Sql("INSERT INTO[dbo].[Activites] ([Id], [Title], [Docket_Id], [Lat], [Lng]) VALUES(2, N'Shedd', 1, 41.867733, -87.613161)");
            Sql("SET IDENTITY_INSERT[dbo].[Activites] OFF");
    }
        
        public override void Down()
        {
        }
    }
}
