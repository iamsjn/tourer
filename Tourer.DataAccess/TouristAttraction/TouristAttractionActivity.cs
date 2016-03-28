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
        ICollection<TouristAttraction> touristAttractions = null;
        public TouristAttractionActivity() { _oTouristAttractionDA = new TouristAttractionDA(); }
        public IEnumerable<TouristAttraction> GetTouristAttractions(ICollection<int> IDs)
        {
            touristAttractions = new List<TouristAttraction>();
            touristAttractions = _oTouristAttractionDA.GetTouristAttractions(IDs);
            return touristAttractions;
        }
    }
}