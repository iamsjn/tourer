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
        ICollection<dynamic> touristAttractions = null;
        public TouristAttractionDA() { _oTourerContext = new TourerContext(); }
        public ICollection<dynamic> GetTouristAttractions(ICollection<int> IDs)
        {
            touristAttractions = new List<dynamic>();
            try
            {
                foreach (int id in IDs)
                {
                    dynamic touristAttraction;
                    touristAttraction = _oTourerContext.TouristAttractions.Where(t => t.TouristAttractionID == id).DefaultIfEmpty().Join(_oTourerContext.TADetails, t => t.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TouristAttraction = t, TADetail = d }).First();
                    touristAttractions.Add(touristAttraction);
                }
                return touristAttractions;
            }
            catch (Exception)
            {
                touristAttractions = null;
                return touristAttractions;
            }
        }
        public ICollection<dynamic> GetTouristAttractions()
        {
            touristAttractions = new List<dynamic>();
            try
            {
                touristAttractions = _oTourerContext.TouristAttractions.Join(_oTourerContext.Locations, t => t.LocationID, l => l.LocationID, (t, l) => new { TouristAttraction = t, Location = l }).Join(_oTourerContext.TADetails, t => t.TouristAttraction.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TouristAttraction = t, TADetail = d }).Take(CommonHelper.GenerateRandomNumber(2, 8)).ToList<dynamic>();
                return touristAttractions;
            }
            catch (Exception)
            {
                touristAttractions = null;
                return touristAttractions;
            }
        }
        public ICollection<dynamic> GetTouristAttractions(int locationID)
        {
            touristAttractions = new List<dynamic>();
            try
            {
                touristAttractions = _oTourerContext.TouristAttractions.Where(t=>t.LocationID == locationID).Join(_oTourerContext.Locations, t => t.LocationID, l => l.LocationID, (t, l) => new { TouristAttraction = t, Location = l }).Join(_oTourerContext.TADetails, t => t.TouristAttraction.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TouristAttraction = t, TADetail = d }).Take(CommonHelper.GenerateRandomNumber(2, 8)).ToList<dynamic>();
                return touristAttractions;
            }
            catch (Exception)
            {
                touristAttractions = null;
                return touristAttractions;
            }
        }
    }
}