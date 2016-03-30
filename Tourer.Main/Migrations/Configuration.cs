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

            //var locations = new List<Location>
            //{
            //new Location{LocationID=1, Name="Dhaka", Latitude="45'0", Longitude="46'67", CreatedDate=DateTime.Parse("2016/03/28") },
            //};

            //locations.ForEach(s => context.Locations.Add(s));
            //context.SaveChanges();

            //var touristAttractions = new List<TouristAttraction>
            //{
            //new TouristAttraction{LocationID=1, Name="Ahsan Manzil", CreatedDate=DateTime.Parse("2016/03/28") },
            //new TouristAttraction{LocationID=1, Name="Lalbag Fort", CreatedDate=DateTime.Parse("2016/03/28")},
            //new TouristAttraction{LocationID=1, Name="Nabab Villa", CreatedDate=DateTime.Parse("2016/03/28")}
            //};

            //touristAttractions.ForEach(s => context.TouristAttractions.Add(s));
            //context.SaveChanges();

            //var tADetails = new List<TADetail>
            //{
            //new TADetail{TouristAttractionID=1, Detail="Ahsan Manzil is a nice place for making a tour.", CreatedDate=DateTime.Parse("2016/03/28") },
            //new TADetail{TouristAttractionID=2, Detail="Lalbag Fort is a nice place for making a tour.", CreatedDate=DateTime.Parse("2016/03/28")},
            //new TADetail{TouristAttractionID=3, Detail="Nabab Villa is a nice place for making a tour.", CreatedDate=DateTime.Parse("2016/03/28")}
            //};

            //tADetails.ForEach(s => context.TADetails.Add(s));
            //context.SaveChanges();

            //var tAttractionSeasonInfos = new List<TAttractionSeasonInfo>
            //{
            //new TAttractionSeasonInfo{TouristAttractionID=1, Season=3, CreatedDate=DateTime.Parse("2016/03/28") },
            //new TAttractionSeasonInfo{TouristAttractionID=2, Season=3, CreatedDate=DateTime.Parse("2016/03/28")},
            //new TAttractionSeasonInfo{TouristAttractionID=3, Season=3, CreatedDate=DateTime.Parse("2016/03/28")}
            //};

            //tAttractionSeasonInfos.ForEach(s => context.TAttractionSeasonInfos.Add(s));
            //context.SaveChanges();
        }
    }
}
