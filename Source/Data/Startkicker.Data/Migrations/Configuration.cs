namespace PayItForward.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PayItForward.Data;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Common;
    public sealed class Configuration : DbMigrationsConfiguration<PayItForwardDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PayItForwardDbContext context)
        {
            SeedCategories(context);
            SeedRoles(context);
            SeedAdmin(context);
        }

        private void SeedRoles(PayItForwardDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var adminRole = new IdentityRole { Name = GlobalConstants.RoleAdmin };
                roleManager.Create(adminRole);

                var userRole = new IdentityRole { Name = GlobalConstants.RoleUser };
                roleManager.Create(userRole);

                context.SaveChanges();
            }
        }

        public void SeedAdmin(PayItForwardDbContext context)
        {
            if (!context.Users.Any())
            {

                var userManager = new UserManager<User>(new UserStore<User>(context));
                var adminAleksandra = new User()
                {
                    Email = "aleksandra@gmail.com",
                    UserName = "aleksandra",
                    FirstName = "Aleksandra",
                    LastName = "Stojceva"
                };

                userManager.Create(adminAleksandra, "123456");
                userManager.AddToRole(adminAleksandra.Id, GlobalConstants.RoleAdmin);

                var adminGoran = new User()
                {
                    Email = "goran@gmail.com",
                    UserName = "goran",
                    FirstName = "Goran",
                    LastName = "Cvetkov"
                };

                userManager.Create(adminGoran, "123456");
                userManager.AddToRole(adminGoran.Id, GlobalConstants.RoleAdmin);

                userManager.AddToRole(adminAleksandra.Id, GlobalConstants.RoleAdmin);

                var adminAdrian = new User()
                {
                    Email = "adrian@gmail.com",
                    UserName = "adrian",
                    FirstName = "Adrian",
                    LastName = "Apostolov"
                };

                userManager.Create(adminAdrian, "123456");
                userManager.AddToRole(adminAdrian.Id, GlobalConstants.RoleAdmin);

                context.SaveChanges();
            }
        }

        private void SeedCategories(PayItForwardDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { IsRemoved = false, Name = "Medical" });
                context.Categories.Add(new Category { IsRemoved = false, Name = "Volunteer" });
                context.Categories.Add(new Category { IsRemoved = false, Name = "Emergencies" });
                context.Categories.Add(new Category { IsRemoved = false, Name = "Education" });
                context.Categories.Add(new Category { IsRemoved = false, Name = "Memorials" });
                context.Categories.Add(new Category { IsRemoved = false, Name = "Sports" });
                context.Categories.Add(new Category { IsRemoved = false, Name = "Animals" });
                context.Categories.Add(new Category { IsRemoved = false, Name = "Business" });
                context.Categories.Add(new Category { IsRemoved = false, Name = "Other" });
                context.SaveChanges();
            }
        }
    }
}
