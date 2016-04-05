using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TATypeDA
    {
        ICollection<dynamic> _touristAttractions = null;
        TourerContext _tourerContext = null;
        public TATypeDA() { _tourerContext = new TourerContext(); }
        public ICollection<dynamic> GetSearchResults(string keyword)
        {
            _touristAttractions = new List<dynamic>();
            try
            {
                _touristAttractions = _tourerContext.TATypes.Where(x => x.Name.StartsWith(keyword) || x.Name.Contains(keyword) || x.Name.EndsWith(keyword)).
                                        Join(_tourerContext.TouristAttractions, x => x.TATypeID, t => t.TATypeID, (x, t) => new { TAType = x, TouristAttraction = t }).
                                        Join(_tourerContext.Locations, t => t.TouristAttraction.LocationID, l => l.LocationID, (t, l) => new { Name = t.TouristAttraction.Name, ID = t.TouristAttraction.TouristAttractionID, Photo = t.TouristAttraction.Photo, Type = t.TAType.Name, Location = l.Name }).
                                        ToList<dynamic>();
                return _touristAttractions;
            }
            catch (Exception)
            {
                _touristAttractions = null;
                return _touristAttractions;
            }
        }
    }
}