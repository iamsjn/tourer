using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourer.Model
{
    public class TADetail
    {
        public int TADetailID { get; set; }
        public int TouristAttractionID { get; set; }
        public string Detail { get; set; }
    }
}