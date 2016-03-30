using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tourer.DataAccess;

namespace Tourer.Main.Controllers
{
    public class SuggestionController : ApiController
    {
        IEnumerable<dynamic> _touristAttractions = null;
        [HttpPost]
        public IEnumerable<dynamic> GetTouristAttractionSuggestion(int locationID)
        {
            TouristAttractionActivity oTouristAttractionActivity = new TouristAttractionActivity();
            _touristAttractions = new List<dynamic>();

            _touristAttractions = oTouristAttractionActivity.GetTouristAttractions(locationID);

            return _touristAttractions;
        }
    }
}
