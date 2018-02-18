namespace Trogsoft.Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_ModuleContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "ModuleContext", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "ModuleContext");
        }
    }
}
