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
    }
}