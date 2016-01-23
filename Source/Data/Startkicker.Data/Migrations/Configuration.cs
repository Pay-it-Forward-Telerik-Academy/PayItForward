namespace PayItForward.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
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
            IList<Category> categories = new List<Category>();

            categories.Add(new Category { IsRemoved = false, Name = "Sport" });
            categories.Add(new Category { IsRemoved = false, Name = "Education" });
            categories.Add(new Category { IsRemoved = false, Name = "Culture" });

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

        }
    }
}
