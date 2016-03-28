using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tourer.Model
{
    public class Location
    {
        public int LocationID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public IEnumerable<TouristAttraction> TouristAttraction { get; set; }
    }
}