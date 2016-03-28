﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tourer.Model
{
    public class TouristAttraction
    {
        public int TouristAttractionID { get; set; }
        [Required]
        public int LocationID { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhotoOne { get; set; }
        public string PhotoTwo { get; set; }
        public string PhotoThree { get; set; }
        public string PhotoFour { get; set; }
        public string PhotoFive { get; set; }
        public string PhotoSix { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public IEnumerable<TAttractionSeasonInfo> TAttractionSeasonInfo { get; set; }
        public virtual Location Location { get; set; }
        public virtual TADetail TADetail { get; set; }
    }
}