using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourer.DataAccess
{
    public class LocationActivity
    {
        LocationDA _oLocationDA = null;
        ICollection<int> _locationIDs = null;
        public LocationActivity() { _oLocationDA = new LocationDA(); }
        public ICollection<int> GetLocationIDs()
        {
            _locationIDs = new List<int>();
            _locationIDs = _oLocationDA.GetLocationIDs();
            return _locationIDs;
        }
    }
}