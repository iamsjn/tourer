namespace Tourer.Main.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tourer.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<Tourer.Model.TourerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Tourer.Model.TourerContext";
        }

        protected override void Seed(Tourer.Model.TourerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var seasons = new List<Season>
            //{
            //new Season{Name="Winter", CreatedDate=DateTime.Parse("2016/03/28") },
            //new Season{Name="Summer", CreatedDate=DateTime.Parse("2016/03/28")},
            //new Season{Name="Rainy", CreatedDate=DateTime.Parse("2016/03/28")}
            //};

            //seasons.ForEach(s => context.Seasons.Add(s));
            //context.SaveChanges();
        }
    }
}
