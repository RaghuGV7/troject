namespace Trogsoft.Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
        }
    }
}
