using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TouristAttractionDA
    {
        TourerContext _oTourerContext = null;
        ICollection<TouristAttraction> touristAttractions = null;
        public TouristAttractionDA() { _oTourerContext = new TourerContext(); }
        public ICollection<TouristAttraction> GetTouristAttractions(ICollection<int> IDs)
        {
            touristAttractions = new List<TouristAttraction>();

            foreach (int id in IDs)
            {
                TouristAttraction touristAttraction;
                touristAttraction = _oTourerContext.TouristAttractions.Where(t=>t.TouristAttractionID == id).DefaultIfEmpty().Join(_oTourerContext.TADetails, t=>t.TouristAttractionID, d=>d.TouristAttractionID, (t, d)=> t).First();
                touristAttractions.Add(touristAttraction);
            }
            return touristAttractions;
        }
    }
}