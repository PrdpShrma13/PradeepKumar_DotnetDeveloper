namespace Pradeep_DotnetDeveloper.Migrations
{
    using Pradeep_DotnetDeveloper.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pradeep_DotnetDeveloper.Data.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Pradeep_DotnetDeveloper.Data.Context.ApplicationDbContext";
        }

        protected override void Seed(Pradeep_DotnetDeveloper.Data.Context.ApplicationDbContext context)
        {
            
        }
    }
}
