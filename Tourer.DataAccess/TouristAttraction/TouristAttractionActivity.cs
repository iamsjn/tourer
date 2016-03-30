using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TouristAttractionActivity
    {
        TouristAttractionDA _touristAttractionDA = null;
        ICollection<dynamic> _touristAttractions = null;
        public TouristAttractionActivity() { _touristAttractionDA = new TouristAttractionDA(); }
        public IEnumerable<dynamic> GetTouristAttractions(ICollection<int> IDs)
        {
            _touristAttractions = new List<dynamic>();
            _touristAttractions = _touristAttractionDA.GetTouristAttractions(IDs);
            return _touristAttractions;
        }
        public IEnumerable<dynamic> GetTouristAttractions()
        {
            _touristAttractions = new List<dynamic>();
            _touristAttractions = _touristAttractionDA.GetTouristAttractions();
            return _touristAttractions;
        }
        public IEnumerable<dynamic> GetTouristAttractions(int locationID)
        {
            _touristAttractions = new List<dynamic>();
            _touristAttractions = _touristAttractionDA.GetTouristAttractions(locationID);
            return _touristAttractions;
        }

        public IEnumerable<dynamic> GetSearchResults(string searchKeyword)
        {
            _touristAttractions = new List<dynamic>();
            _touristAttractions = _touristAttractionDA.GetSearchResults(searchKeyword);
            return _touristAttractions;
        }
    }
}