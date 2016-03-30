using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourer.DataAccess
{
    public class LocationActivity
    {
        LocationDA _locationDA = null;
        ICollection<int> _locationIDs = null;
        ICollection<dynamic> _touristAttractions = null;
        public LocationActivity() { _locationDA = new LocationDA(); }
        public ICollection<int> GetLocationIDs()
        {
            _locationIDs = new List<int>();
            _locationIDs = _locationDA.GetLocationIDs();
            return _locationIDs;
        }
        public IEnumerable<dynamic> GetSearchResults(string searchKeyword)
        {
            _touristAttractions = new List<dynamic>();
            _touristAttractions = _locationDA.GetSearchResults(searchKeyword);
            return _touristAttractions;
        }
    }
}