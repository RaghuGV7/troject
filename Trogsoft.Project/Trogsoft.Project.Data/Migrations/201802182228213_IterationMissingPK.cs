namespace Trogsoft.Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IterationMissingPK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task", "IterationId", "dbo.Iteration");
            DropPrimaryKey("dbo.Iteration");
            AlterColumn("dbo.Iteration", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Iteration", "Id");
            AddForeignKey("dbo.Task", "IterationId", "dbo.Iteration", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "IterationId", "dbo.Iteration");
            DropPrimaryKey("dbo.Iteration");
            AlterColumn("dbo.Iteration", "Id", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Iteration", "Id");
            AddForeignKey("dbo.Task", "IterationId", "dbo.Iteration", "Id");
        }
    }
}
