namespace ChooseMe.Web.App_Start
{
    using System.Data.Entity;
    using Data;
    using ChooseMe.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChooseMeDbContext, Configuration>());
            ChooseMeDbContext.Create().Database.Initialize(true);
        }
    }
}