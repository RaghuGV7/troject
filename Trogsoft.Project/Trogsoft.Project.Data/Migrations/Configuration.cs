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

            if (!context.Users.Any(x => x.Username == "admin"))
            {
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
            }
        }
    }
}
