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
            //new Location{Name="Lalbag", ParentID = 2, Latitude="45'0", Longitude="46'67", CreatedDate=DateTime.Parse("2016/03/28") },
            //};

            //locations.ForEach(s => context.Locations.Add(s));
            //context.SaveChanges();

            //var touristAttractions = new List<TouristAttraction>
            //{
            //new TouristAttraction{LocationID=3, TATypeID=16, Name="Ahsan Manzil", Photo="/Images/TA16/Photo.jpg", BannerPhoto="/Images/TA16/BannerPhoto.jpg", CreatedDate=DateTime.Parse("2016/03/28") },
            //new TouristAttraction{LocationID=3, TATypeID=17, Name="Lalbag Fort", Photo="/Images/TA17/Photo.jpg", BannerPhoto="/Images/TA17/BannerPhoto.jpg", CreatedDate=DateTime.Parse("2016/03/28")},
            //new TouristAttraction{LocationID=2, TATypeID=18, Name="Nabab Villa", Photo="/Images/TA18/Photo.jpg", BannerPhoto="/Images/TA18/BannerPhoto.jpg", CreatedDate=DateTime.Parse("2016/03/28")}
            //};

            //touristAttractions.ForEach(s => context.TouristAttractions.Add(s));
            //context.SaveChanges();

            //var tADetails = new List<TADetail>
            //{
            //new TADetail{TouristAttractionID=16, Detail="/Details/TA16/Detail.html", CreatedDate=DateTime.Parse("2016/03/28") },
            //new TADetail{TouristAttractionID=17, Detail="/Details/TA17/Detail.html", CreatedDate=DateTime.Parse("2016/03/28")},
            //new TADetail{TouristAttractionID=18, Detail="/Details/TA18/Detail.html", CreatedDate=DateTime.Parse("2016/03/28")}
            //};

            //tADetails.ForEach(s => context.TADetails.Add(s));
            //context.SaveChanges();

            //var reviews = new List<TAReview>
            //{
            //new TAReview{ Rating=5, TouristAttractionID=17, UserID=28, Review="It's a nice place.", CreatedDate=DateTime.Parse("2016/03/28") },
            //new TAReview{ Rating=3, TouristAttractionID=17, UserID=30, Review="Beautiful for tour.", CreatedDate=DateTime.Parse("2016/03/28") },
            //new TAReview{ Rating=5, TouristAttractionID=17, ParentID=3, UserID=29, Review="Yeah, You're right.", CreatedDate=DateTime.Parse("2016/03/28") }
            //};

            //reviews.ForEach(s => context.TAReviews.Add(s));
            //context.SaveChanges();

            //var tAPhotos = new List<TAPhoto>
            //{
            //new TAPhoto{ Photo = "/Images/TAPhoto/TA17/Photo.jpg", TouristAttractionID=17, CreatedDate=DateTime.Parse("2016/03/28") },
            //new TAPhoto{ Photo = "/Images/TAPhoto/TA17/Photo.jpg", TouristAttractionID=17, CreatedDate=DateTime.Parse("2016/03/28") },
            //new TAPhoto{ Photo = "/Images/TAPhoto/TA17/Photo.jpg", TouristAttractionID=17, CreatedDate=DateTime.Parse("2016/03/28") },
            //new TAPhoto{ Photo = "/Images/TAPhoto/TA17/Photo.jpg", TouristAttractionID=17, CreatedDate=DateTime.Parse("2016/03/28") },
            //};

            //tAPhotos.ForEach(s => context.TAPhotos.Add(s));
            //context.SaveChanges();

            //var tAttractionSeasonInfos = new List<TAttractionSeasonInfo>
            //{
            //new TAttractionSeasonInfo{TouristAttractionID=17, Season=3, CreatedDate=DateTime.Parse("2016/03/28") },
            //new TAttractionSeasonInfo{TouristAttractionID=18, Season=3, CreatedDate=DateTime.Parse("2016/03/28")},
            //new TAttractionSeasonInfo{TouristAttractionID=16, Season=3, CreatedDate=DateTime.Parse("2016/03/28")}
            //};

            //tAttractionSeasonInfos.ForEach(s => context.TAttractionSeasonInfos.Add(s));
            //context.SaveChanges();

            //var tATypes = new List<TAType>
            //{
            //new TAType{Name="Historical", CreatedDate=DateTime.Parse("2016/03/28") },
            //new TAType{Name="Archeological", CreatedDate=DateTime.Parse("2016/03/28")},
            //new TAType{Name="Temple", CreatedDate=DateTime.Parse("2016/03/28")}
            //};

            //tATypes.ForEach(s => context.TATypes.Add(s));
            //context.SaveChanges();
        }
    }
}
