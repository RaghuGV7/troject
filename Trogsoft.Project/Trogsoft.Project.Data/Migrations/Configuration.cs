namespace Trogsoft.Project.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BCrypt.Net;

    internal sealed class Configuration : DbMigrationsConfiguration<Trogsoft.Project.Data.ProjectEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Trogsoft.Project.Data.ProjectEntities context)
        {
            //  This method will be called after migrating to the latest version.

            context.AuthModules.AddOrUpdate(
                x => x.Name,
                new AuthModule
                {
                    Name = "ActiveDirectoryAuthModule",
                    Ordinal = 100
                });

            context.AuthModules.AddOrUpdate(
                x => x.Name,
                new AuthModule
                {
                    Name = "InternalAuthModule",
                    Ordinal = 0
                });

            context.SaveChanges();

            var password = "Password123";
            var hashedPassword = BCrypt.HashPassword(password);

            context.Users.AddOrUpdate(
                x => x.Username,
                new User
                {
                    AuthModuleId = context.AuthModules.SingleOrDefault(x => x.Name == "InternalAuthModule")?.Id,
                    EmailAddress = "none@example.com",
                    Password = hashedPassword,
                    Username = "admin",
                    FirstName = "Administration",
                    LastName = "User",
                    DisplayName = "Administration User"
                });


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
