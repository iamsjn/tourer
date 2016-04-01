using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class LocationDA
    {
        ICollection<int> _locationIDs = null;
        ICollection<dynamic> _touristAttractions = null;
        TourerContext _tourerContext = null;
        public LocationDA() { _tourerContext = new TourerContext(); }
        public ICollection<int> GetLocationIDs()
        {
            _locationIDs = new List<int>();
            try
            {
                _locationIDs = _tourerContext.Locations.Select(l => l.LocationID).Take(CommonHelper.GenerateRandomNumber(2, 8)).ToList();
                return _locationIDs;
            }
            catch (Exception)
            {
                _locationIDs = null;
                return _locationIDs;
            }
        }
        public ICollection<dynamic> GetSearchResults(string keyword)
        {
            _touristAttractions = new List<dynamic>();
            try
            {
                //_touristAttractions = _tourerContext.Locations.Where(l => l.Name.StartsWith(keyword) || l.Name.Contains(keyword) || l.Name.EndsWith(keyword)).Join(_tourerContext.TouristAttractions, l => l.LocationID, t => t.LocationID, (l, t) => new { Location = l, TouristAttraction = t }).Join(_tourerContext.TADetails, t => t.TouristAttraction.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TAName = t.TouristAttraction.Name, TAID = t.TouristAttraction.TouristAttractionID, TALocation = t.Location.Name, TALocationID = t.Location.LocationID, TALocationLongitude = t.Location.Longitude, TALocationLattitude = t.Location.Latitude, TADetail = d.Detail }).ToList<dynamic>();
                _touristAttractions = _tourerContext.Locations.Where(l => l.Name.StartsWith(keyword) || l.Name.Contains(keyword) || l.Name.EndsWith(keyword)).
                                        Join(_tourerContext.TouristAttractions, l => l.LocationID, t => t.LocationID, (l, t) => new { Location = l, TouristAttraction = t }).
                                        Join(_tourerContext.TATypes, t => t.TouristAttraction.TATypeID, x => x.TATypeID, (t, l) => new { TAL = t, TAType = l }).
                                        Join(_tourerContext.TADetails, t => t.TAL.TouristAttraction.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TAName = t.TAL.TouristAttraction.Name, TAID = t.TAL.TouristAttraction.TouristAttractionID, TAType = t.TAType.Name, TATypeID = t.TAType.TATypeID, TALocation = t.TAL.Location.Name, TALocationID = t.TAL.Location.LocationID, TALocationLongitude = t.TAL.Location.Longitude, TALocationLattitude = t.TAL.Location.Latitude, TADetail = d.Detail }).
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