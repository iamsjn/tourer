using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TouristAttractionActivity
    {
        TouristAttractionDA _oTouristAttractionDA = null;
        ICollection<dynamic> touristAttractions = null;
        public TouristAttractionActivity() { _oTouristAttractionDA = new TouristAttractionDA(); }
        public IEnumerable<dynamic> GetTouristAttractions(ICollection<int> IDs)
        {
            touristAttractions = new List<dynamic>();
            touristAttractions = _oTouristAttractionDA.GetTouristAttractions(IDs);
            return touristAttractions;
        }

        public IEnumerable<dynamic> GetTouristAttractions()
        {
            touristAttractions = new List<dynamic>();
            touristAttractions = _oTouristAttractionDA.GetTouristAttractions();
            return touristAttractions;
        }
    }
}