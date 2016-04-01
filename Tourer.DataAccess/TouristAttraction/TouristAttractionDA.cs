using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TouristAttractionDA
    {
        TourerContext _tourerContext = null;
        ICollection<dynamic> _touristAttractions = null;
        public TouristAttractionDA() { _tourerContext = new TourerContext(); }
        public ICollection<dynamic> GetTouristAttractions(ICollection<int> IDs)
        {
            _touristAttractions = new List<dynamic>();
            try
            {
                foreach (int id in IDs)
                {
                    dynamic touristAttraction;
                    touristAttraction = _tourerContext.TouristAttractions.Where(t => t.TouristAttractionID == id).Join(_tourerContext.Locations, t => t.LocationID, l => l.LocationID, (t, l) => new { TouristAttraction = t, Location = l }).Join(_tourerContext.TADetails, t => t.TouristAttraction.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TAName = t.TouristAttraction.Name, TAID = t.TouristAttraction.TouristAttractionID, TALocation = t.Location.Name, TALocationID = t.Location.LocationID, TALocationLongitude = t.Location.Longitude, TALocationLattitude = t.Location.Latitude, TADetail = d.Detail }).ToList<dynamic>().First();
                    _touristAttractions.Add(touristAttraction);
                }
                return _touristAttractions;
            }
            catch (Exception)
            {
                _touristAttractions = null;
                return _touristAttractions;
            }
        }
        public ICollection<dynamic> GetTouristAttractions()
        {
            _touristAttractions = new List<dynamic>();
            try
            {
                //_touristAttractions = _tourerContext.TouristAttractions.Join(_tourerContext.Locations, t => t.LocationID, l => l.LocationID, (t, l) => new { TouristAttraction = t, Location = l }).Join(_tourerContext.TADetails, t => t.TouristAttraction.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TAName = t.TouristAttraction.Name, TAID = t.TouristAttraction.TouristAttractionID, TALocation = t.Location.Name, TALocationID = t.Location.LocationID, TALocationLongitude = t.Location.Longitude, TALocationLattitude = t.Location.Latitude, TADetail = d.Detail }).ToList<dynamic>();
                _touristAttractions = _tourerContext.TouristAttractions.
                                        Join(_tourerContext.TATypes, t => t.TATypeID, x => x.TATypeID, (t, x) => new { TouristAttraction = t, TAType = x, }).
                                        Join(_tourerContext.Locations, t => t.TouristAttraction.LocationID, l => l.LocationID, (t, l) => new { TATY = t, Location = l }).
                                        Join(_tourerContext.TADetails, t => t.TATY.TouristAttraction.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TAName = t.TATY.TouristAttraction.Name, TAID = t.TATY.TouristAttraction.TouristAttractionID, TAType = t.TATY.TAType.Name, TATypeID = t.TATY.TAType.TATypeID, TALocation = t.Location.Name, TALocationID = t.Location.LocationID, TALocationLongitude = t.Location.Longitude, TALocationLattitude = t.Location.Latitude, TADetail = d.Detail }).
                                        Take(CommonHelper.GenerateRandomNumber(2, 8)).ToList<dynamic>();
                return _touristAttractions;
            }
            catch (Exception)
            {
                _touristAttractions = null;
                return _touristAttractions;
            }
        }
        public ICollection<dynamic> GetTouristAttractions(int locationID)
        {
            _touristAttractions = new List<dynamic>();
            try
            {
                //_touristAttractions = _tourerContext.TouristAttractions.Where(t => t.LocationID == locationID).Join(_tourerContext.Locations, t => t.LocationID, l => l.LocationID, (t, l) => new { TouristAttraction = t, Location = l }).Join(_tourerContext.TADetails, t => t.TouristAttraction.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TAName = t.TouristAttraction.Name, TAID = t.TouristAttraction.TouristAttractionID, TALocation = t.Location.Name, TALocationID = t.Location.LocationID, TALocationLongitude = t.Location.Longitude, TALocationLattitude = t.Location.Latitude, TADetail = d.Detail }).Take(CommonHelper.GenerateRandomNumber(2, 8)).ToList<dynamic>();
                _touristAttractions = _tourerContext.TouristAttractions.Where(t => t.LocationID == locationID).
                                        Join(_tourerContext.TATypes, t => t.TATypeID, x => x.TATypeID, (t, x) => new { TouristAttraction = t, TAType = x, }).
                                        Join(_tourerContext.Locations, t => t.TouristAttraction.LocationID, l => l.LocationID, (t, l) => new { TATY = t, Location = l }).
                                        Join(_tourerContext.TADetails, t => t.TATY.TouristAttraction.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TAName = t.TATY.TouristAttraction.Name, TAID = t.TATY.TouristAttraction.TouristAttractionID, TAType = t.TATY.TAType.Name, TATypeID = t.TATY.TAType.TATypeID, TALocation = t.Location.Name, TALocationID = t.Location.LocationID, TALocationLongitude = t.Location.Longitude, TALocationLattitude = t.Location.Latitude, TADetail = d.Detail }).
                                        Take(CommonHelper.GenerateRandomNumber(2, 8)).ToList<dynamic>();
                return _touristAttractions;
            }
            catch (Exception)
            {
                _touristAttractions = null;
                return _touristAttractions;
            }
        }
        public ICollection<dynamic> GetSearchResults(string searchKeyword)
        {
            _touristAttractions = new List<dynamic>();
            try
            {
                //_touristAttractions = _tourerContext.TouristAttractions.Where(t => t.Name.StartsWith(searchKeyword) || t.Name.Contains(searchKeyword) || t.Name.EndsWith(searchKeyword)).Join(_tourerContext.Locations, t => t.LocationID, l => l.LocationID, (t, l) => new { TouristAttraction = t, Location = l }).Join(_tourerContext.TADetails, t => t.TouristAttraction.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TAName = t.TouristAttraction.Name, TAID = t.TouristAttraction.TouristAttractionID, TALocation = t.Location.Name, TALocationID = t.Location.LocationID, TALocationLongitude = t.Location.Longitude, TALocationLattitude = t.Location.Latitude, TADetail = d.Detail }).ToList<dynamic>();
                _touristAttractions = _tourerContext.TouristAttractions.Where(t => t.Name.StartsWith(searchKeyword) || t.Name.Contains(searchKeyword) || t.Name.EndsWith(searchKeyword)).
                                        Join(_tourerContext.TATypes, t => t.TATypeID, x => x.TATypeID, (t, x) => new { TouristAttraction = t, TAType = x, }).
                                        Join(_tourerContext.Locations, t => t.TouristAttraction.LocationID, l => l.LocationID, (t, l) => new { TATY = t, Location = l }).
                                        Join(_tourerContext.TADetails, t => t.TATY.TouristAttraction.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { TAName = t.TATY.TouristAttraction.Name, TAID = t.TATY.TouristAttraction.TouristAttractionID, TAType = t.TATY.TAType.Name, TATypeID = t.TATY.TAType.TATypeID, TALocation = t.Location.Name, TALocationID = t.Location.LocationID, TALocationLongitude = t.Location.Longitude, TALocationLattitude = t.Location.Latitude, TADetail = d.Detail }).
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