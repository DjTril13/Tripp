namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDocket : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT[dbo].[Dockets] ON");
            Sql("INSERT INTO[dbo].[Dockets]([Id], [Title]) VALUES(1, 'Chicago')");
            Sql("SET IDENTITY_INSERT[dbo].[Dockets] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
