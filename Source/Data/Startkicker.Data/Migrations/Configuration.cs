namespace PayItForward.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PayItForward.Data;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<PayItForwardDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PayItForwardDbContext context)
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
