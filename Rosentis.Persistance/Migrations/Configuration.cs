namespace Rosentis.Persistance.Migrations
{
	using Rosentis.Persistance.Facade;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rosentis.Persistance.Facade.RosentisContext>
    {
        public Configuration()
        {
			AutomaticMigrationsEnabled = true;
			ContextKey = "Blank.Persistance.Facade.BlankContext";
			AutomaticMigrationDataLossAllowed = true;
		}

        protected override void Seed(Rosentis.Persistance.Facade.RosentisContext context)
        {
			try
			{
				RosentisContextInitializer.Seed(context);
			}
			catch (Exception ex)
			{

				throw;
			}
		}
    }
}
