using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tourer.Model
{
    public class TAReview
    {
        public int TAReviewID { get; set; }
        [Required]
        public int TouristAttractionID { get; set; }
        [Required]
        public int UserID { get; set; }
        public int ParentID { get; set; }
        public int Rating { get; set; }
        [MinLength(3)][MaxLength(500)]
        public string Review { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}