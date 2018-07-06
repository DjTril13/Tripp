namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMoreDockets : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT[dbo].[Dockets]  ON");
            Sql("INSERT INTO[dbo].[Dockets] ([Id], [Title]) VALUES(2, N'Logan Square')");
            Sql("INSERT INTO[dbo].[Dockets] ([Id], [Title]) VALUES(3, N'Down Town')");
            Sql("SET IDENTITY_INSERT[dbo].[Dockets] OFF");
    }
        
        public override void Down()
        {
        }
    }
}
