using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Tourer.Model
{
    public class TourerInitializer : DropCreateDatabaseIfModelChanges<TourerContext>
    {
        protected override void Seed(TourerContext context)
        {
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