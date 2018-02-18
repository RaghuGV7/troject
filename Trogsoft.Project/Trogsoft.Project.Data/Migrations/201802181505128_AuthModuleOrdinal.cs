namespace Trogsoft.Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthModuleOrdinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AuthModule", "Ordinal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AuthModule", "Ordinal");
        }
    }
}
