namespace Trogsoft.Project.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectEntities : DbContext
    {
        public ProjectEntities()
            : base("name=TrojectDb")
        {
        }

        public virtual DbSet<ApiKey> ApiKeys { get; set; }
        public virtual DbSet<AuthModule> AuthModules { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Iteration> Iterations { get; set; }
        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Privilege> Privileges { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Timing> Timings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiKey>()
                .HasMany(e => e.Privileges)
                .WithMany(e => e.ApiKeys)
                .Map(m => m.ToTable("ApiKeyPrivilege").MapLeftKey("ApiKeyId").MapRightKey("PrivilegeId"));

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Privileges)
                .WithMany(e => e.Groups)
                .Map(m => m.ToTable("GroupPrivilege").MapLeftKey("GroupId").MapRightKey("PrivilegeId"));

            modelBuilder.Entity<Privilege>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Privileges)
                .Map(m => m.ToTable("UserPrivilege").MapLeftKey("PrivilegeId").MapRightKey("UserId"));

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Iterations)
                .WithOptional(e => e.Project)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Status)
                .WithOptional(e => e.Project)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Tags)
                .WithOptional(e => e.Project)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.Project)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.Tasks)
                .WithMany(e => e.Tags)
                .Map(m => m.ToTable("TaskTag").MapLeftKey("TagId").MapRightKey("TaskId"));

            modelBuilder.Entity<Task>()
                .HasMany(e => e.Task1)
                .WithOptional(e => e.Task2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.Timings)
                .WithOptional(e => e.Task)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Task>()
                .HasMany(e => e.Users)
                .WithMany(e => e.AssignedTasks)
                .Map(m => m.ToTable("AssignedTo").MapLeftKey("TaskId").MapRightKey("UserId"));

            modelBuilder.Entity<Task>()
                .HasMany(e => e.Users1)
                .WithMany(e => e.WatchedTasks)
                .Map(m => m.ToTable("Watch").MapLeftKey("TaskId").MapRightKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.Projects)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Owner);
        }
    }
}
