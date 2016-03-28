using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tourer.Model
{
    public class TAttractionSeasonInfo
    {
        public int TAttractionSeasonInfoID { get; set; }
        [Required]
        public int Season { get; set; }
        [Required]
        public int TouristAttractionID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TouristAttraction TouristAttraction { get; set; }
    }
}