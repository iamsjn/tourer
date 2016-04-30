using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourer.Model
{
    public class UserTAttractionAndReview
    {
        public User User { get; set; }
        public TouristAttraction TouristAttraction { get; set; }
        public TAReview TAReview { get; set; }
    }
}