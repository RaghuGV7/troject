namespace Trogsoft.Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDeploy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApiKey",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrganisationId = c.Long(),
                        ApiKey = c.String(),
                        Created = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisation", t => t.OrganisationId)
                .Index(t => t.OrganisationId);
            
            CreateTable(
                "dbo.Organisation",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        UrlPortion = c.String(nullable: false),
                        Package = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        OrganisationId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisation", t => t.OrganisationId)
                .Index(t => t.OrganisationId);
            
            CreateTable(
                "dbo.Privilege",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        OrganisationId = c.Long(),
                        EmailAddress = c.String(nullable: false),
                        AuthModuleId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuthModule", t => t.AuthModuleId)
                .ForeignKey("dbo.Organisation", t => t.OrganisationId)
                .Index(t => t.OrganisationId)
                .Index(t => t.AuthModuleId);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProjectId = c.Long(),
                        IterationId = c.Long(),
                        StatusId = c.Long(),
                        ParentId = c.Long(),
                        Title = c.String(nullable: false),
                        Owner = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PriorityId = c.Long(),
                        TaskType = c.String(),
                        IsTouched = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Iteration", t => t.IterationId)
                .ForeignKey("dbo.Priority", t => t.PriorityId)
                .ForeignKey("dbo.Task", t => t.ParentId)
                .Index(t => t.ProjectId)
                .Index(t => t.IterationId)
                .Index(t => t.StatusId)
                .Index(t => t.ParentId)
                .Index(t => t.PriorityId);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TaskId = c.Long(),
                        ContentType = c.Int(),
                        Owner = c.Long(),
                        Date = c.DateTime(precision: 7, storeType: "datetime2"),
                        Value = c.String(),
                        StructureType = c.String(),
                        IsNotifyComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Task", t => t.TaskId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Iteration",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ProjectId = c.Long(),
                        Title = c.String(),
                        StartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Owner = c.Long(),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        OrganisationId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisation", t => t.OrganisationId)
                .ForeignKey("dbo.User", t => t.Owner)
                .Index(t => t.Owner)
                .Index(t => t.OrganisationId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProjectId = c.Long(),
                        Title = c.String(),
                        IsClosed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProjectId = c.Long(),
                        Code = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Priority",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Ordinal = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Timing",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TaskId = c.Long(),
                        TimingType = c.Int(),
                        Value = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Task", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.AuthModule",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ModulePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Value = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskTag",
                c => new
                    {
                        TagId = c.Long(nullable: false),
                        TaskId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.TaskId })
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: false)
                .ForeignKey("dbo.Task", t => t.TaskId, cascadeDelete: false)
                .Index(t => t.TagId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.AssignedTo",
                c => new
                    {
                        TaskId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.TaskId, t.UserId })
                .ForeignKey("dbo.Task", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Watch",
                c => new
                    {
                        TaskId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.TaskId, t.UserId })
                .ForeignKey("dbo.Task", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserPrivilege",
                c => new
                    {
                        PrivilegeId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrivilegeId, t.UserId })
                .ForeignKey("dbo.Privilege", t => t.PrivilegeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PrivilegeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GroupPrivilege",
                c => new
                    {
                        GroupId = c.Long(nullable: false),
                        PrivilegeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.PrivilegeId })
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Privilege", t => t.PrivilegeId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.PrivilegeId);
            
            CreateTable(
                "dbo.ApiKeyPrivilege",
                c => new
                    {
                        ApiKeyId = c.Long(nullable: false),
                        PrivilegeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApiKeyId, t.PrivilegeId })
                .ForeignKey("dbo.ApiKey", t => t.ApiKeyId, cascadeDelete: true)
                .ForeignKey("dbo.Privilege", t => t.PrivilegeId, cascadeDelete: true)
                .Index(t => t.ApiKeyId)
                .Index(t => t.PrivilegeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApiKeyPrivilege", "PrivilegeId", "dbo.Privilege");
            DropForeignKey("dbo.ApiKeyPrivilege", "ApiKeyId", "dbo.ApiKey");
            DropForeignKey("dbo.GroupPrivilege", "PrivilegeId", "dbo.Privilege");
            DropForeignKey("dbo.GroupPrivilege", "GroupId", "dbo.Group");
            DropForeignKey("dbo.UserPrivilege", "UserId", "dbo.User");
            DropForeignKey("dbo.UserPrivilege", "PrivilegeId", "dbo.Privilege");
            DropForeignKey("dbo.Project", "Owner", "dbo.User");
            DropForeignKey("dbo.User", "OrganisationId", "dbo.Organisation");
            DropForeignKey("dbo.User", "AuthModuleId", "dbo.AuthModule");
            DropForeignKey("dbo.Watch", "UserId", "dbo.User");
            DropForeignKey("dbo.Watch", "TaskId", "dbo.Task");
            DropForeignKey("dbo.AssignedTo", "UserId", "dbo.User");
            DropForeignKey("dbo.AssignedTo", "TaskId", "dbo.Task");
            DropForeignKey("dbo.Timing", "TaskId", "dbo.Task");
            DropForeignKey("dbo.Task", "ParentId", "dbo.Task");
            DropForeignKey("dbo.Task", "PriorityId", "dbo.Priority");
            DropForeignKey("dbo.Task", "IterationId", "dbo.Iteration");
            DropForeignKey("dbo.Task", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Tag", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.TaskTag", "TaskId", "dbo.Task");
            DropForeignKey("dbo.TaskTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.Status", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Task", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Project", "OrganisationId", "dbo.Organisation");
            DropForeignKey("dbo.Iteration", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Content", "TaskId", "dbo.Task");
            DropForeignKey("dbo.Group", "OrganisationId", "dbo.Organisation");
            DropForeignKey("dbo.ApiKey", "OrganisationId", "dbo.Organisation");
            DropIndex("dbo.ApiKeyPrivilege", new[] { "PrivilegeId" });
            DropIndex("dbo.ApiKeyPrivilege", new[] { "ApiKeyId" });
            DropIndex("dbo.GroupPrivilege", new[] { "PrivilegeId" });
            DropIndex("dbo.GroupPrivilege", new[] { "GroupId" });
            DropIndex("dbo.UserPrivilege", new[] { "UserId" });
            DropIndex("dbo.UserPrivilege", new[] { "PrivilegeId" });
            DropIndex("dbo.Watch", new[] { "UserId" });
            DropIndex("dbo.Watch", new[] { "TaskId" });
            DropIndex("dbo.AssignedTo", new[] { "UserId" });
            DropIndex("dbo.AssignedTo", new[] { "TaskId" });
            DropIndex("dbo.TaskTag", new[] { "TaskId" });
            DropIndex("dbo.TaskTag", new[] { "TagId" });
            DropIndex("dbo.Timing", new[] { "TaskId" });
            DropIndex("dbo.Tag", new[] { "ProjectId" });
            DropIndex("dbo.Status", new[] { "ProjectId" });
            DropIndex("dbo.Project", new[] { "OrganisationId" });
            DropIndex("dbo.Project", new[] { "Owner" });
            DropIndex("dbo.Iteration", new[] { "ProjectId" });
            DropIndex("dbo.Content", new[] { "TaskId" });
            DropIndex("dbo.Task", new[] { "PriorityId" });
            DropIndex("dbo.Task", new[] { "ParentId" });
            DropIndex("dbo.Task", new[] { "StatusId" });
            DropIndex("dbo.Task", new[] { "IterationId" });
            DropIndex("dbo.Task", new[] { "ProjectId" });
            DropIndex("dbo.User", new[] { "AuthModuleId" });
            DropIndex("dbo.User", new[] { "OrganisationId" });
            DropIndex("dbo.Group", new[] { "OrganisationId" });
            DropIndex("dbo.ApiKey", new[] { "OrganisationId" });
            DropTable("dbo.ApiKeyPrivilege");
            DropTable("dbo.GroupPrivilege");
            DropTable("dbo.UserPrivilege");
            DropTable("dbo.Watch");
            DropTable("dbo.AssignedTo");
            DropTable("dbo.TaskTag");
            DropTable("dbo.Setting");
            DropTable("dbo.AuthModule");
            DropTable("dbo.Timing");
            DropTable("dbo.Priority");
            DropTable("dbo.Tag");
            DropTable("dbo.Status");
            DropTable("dbo.Project");
            DropTable("dbo.Iteration");
            DropTable("dbo.Content");
            DropTable("dbo.Task");
            DropTable("dbo.User");
            DropTable("dbo.Privilege");
            DropTable("dbo.Group");
            DropTable("dbo.Organisation");
            DropTable("dbo.ApiKey");
        }
    }
}
