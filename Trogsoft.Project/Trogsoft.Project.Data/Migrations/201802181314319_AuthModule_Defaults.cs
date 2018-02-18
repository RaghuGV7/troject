namespace Trogsoft.Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthModule_Defaults : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AuthModule", "ModulePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AuthModule", "ModulePath", c => c.String(nullable: false));
        }
    }
}
