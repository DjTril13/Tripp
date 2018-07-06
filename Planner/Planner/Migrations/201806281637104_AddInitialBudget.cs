namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialBudget : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT dbo.Budgets ON");
            Sql("INSERT INTO dbo.Budgets (Id, Categories, Amount) VALUES (1, 'InitialBudget', 0)");
        
        }
        
        public override void Down()
        {
        }
    }
}
