using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tourer.DataAccess;

namespace Tourer.Main.Controllers
{
    public class SearchController : ApiController
    {
        ICollection<dynamic> _totalResults = null;
        IEnumerable<dynamic> _touristAttractions = null;
        IEnumerable<dynamic> _locationalTouristAttractions = null;
        IEnumerable<dynamic> _categorizeTouristAttractions = null;

        [HttpPost]
        public IEnumerable<dynamic> SearchTouristAttraction(string searchKeyword)
        {
            TouristAttractionActivity oTouristAttractionActivity = new TouristAttractionActivity();
            LocationActivity oLocationActivity = new LocationActivity();
            _totalResults = new List<dynamic>();
            _touristAttractions = new List<dynamic>();
            _locationalTouristAttractions = new List<dynamic>();
            _categorizeTouristAttractions = new List<dynamic>();

            _touristAttractions = oTouristAttractionActivity.GetSearchResults(searchKeyword);
            _locationalTouristAttractions = oLocationActivity.GetSearchResults(searchKeyword);

            _totalResults.Add(_touristAttractions.Concat(_locationalTouristAttractions).ToList());

            return _touristAttractions;
        }
    }
}
