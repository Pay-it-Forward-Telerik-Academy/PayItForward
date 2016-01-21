namespace PayItForward.WebForms.App_Start
{
    using System.Data.Entity;

    using PayItForward.Data;
    using PayItForward.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PayItForwardDbContext, Configuration>());
            PayItForwardDbContext.Create().Database.Initialize(true);
        }
    }
}