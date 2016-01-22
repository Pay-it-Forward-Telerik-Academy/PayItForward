namespace PayItForward.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using PayItForward.Data;

    public sealed class Configuration : DbMigrationsConfiguration<PayItForwardDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PayItForwardDbContext context)
        {

        }
    }
}
