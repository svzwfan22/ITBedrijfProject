namespace ITBedrijfProject.Migrations
{
    using ITBedrijfProject.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ITBedrijfProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ITBedrijfProject.Models.ApplicationDbContext context)
        {
            string roleAdmin = "Administrator";
            string roleNormalUser = "User";
            IdentityResult roleResult;

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!RoleManager.RoleExists(roleNormalUser))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleNormalUser));
            }

            if (!RoleManager.RoleExists(roleAdmin))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleAdmin));
            }

            if (!context.Users.Any(u => u.Email.Equals("mike.sadonis@student.howest.be")))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    FirstName = "Mike",
                    Name = "Sadonis",
                    Email = "mike.sadonis@student.howest.be",
                    UserName = "mike.sadonis@student.howest.be",
                    Address = "Smissestraat 11",
                    City = "Outrijve",
                    Zipcode = "8582",
                    
                };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, roleAdmin);
            }
        }
    }
}
