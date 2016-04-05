using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Tourer.Model
{
    public class TourerContext : DbContext
    {
        public TourerContext() : base("TourerContext")
        {
            this.Database.CreateIfNotExists();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<GCM> GCMs { get; set; }
        public DbSet<TouristAttraction> TouristAttractions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<TAttractionSeasonInfo> TAttractionSeasonInfos { get; set; }
        public DbSet<TADetail> TADetails { get; set; }
        public DbSet<TAType> TATypes { get; set; }
        public DbSet<UserPhotoAlbum> UserPhotoAlbums { get; set; }
        public DbSet<UserAlbumPhoto> UserAlbumPhotos { get; set; }
        public DbSet<TAReview> TAReviews { get; set; }
        public DbSet<TAPhoto> TAPhotos { get; set; }
    }
}