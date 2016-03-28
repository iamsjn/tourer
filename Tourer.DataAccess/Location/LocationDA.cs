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
        TourerContext _oTourerContext = null;
        public LocationDA() { _oTourerContext = new TourerContext(); }
        public ICollection<int> GetLocationIDs()
        {
            _locationIDs = new List<int>();
            try
            {
                _locationIDs = _oTourerContext.Locations.Select(l => l.LocationID).Take(CommonHelper.GenerateRandomNumber(2, 8)).ToList();
                return _locationIDs;
            }
            catch (Exception)
            {
                _locationIDs = null;
                return _locationIDs;
            }
        }
    }
}