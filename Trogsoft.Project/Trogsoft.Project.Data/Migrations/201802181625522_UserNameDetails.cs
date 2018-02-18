namespace Trogsoft.Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.User", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.User", "DisplayName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "DisplayName");
            DropColumn("dbo.User", "LastName");
            DropColumn("dbo.User", "FirstName");
        }
    }
}
