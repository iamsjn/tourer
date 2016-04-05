using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tourer.DataAccess;
using Newtonsoft.Json.Linq;

namespace Tourer.Main.Controllers
{
    public class SearchController : ApiController
    {
        IEnumerable<dynamic> _touristAttractions = null;
        IEnumerable<dynamic> _locationalTouristAttractions = null;
        IEnumerable<dynamic> _categorizeTouristAttractions = null;
        JObject _data = null;

        [HttpPost]
        public IHttpActionResult SearchTouristAttraction(string searchKeyword)
        {
            TouristAttractionActivity oTouristAttractionActivity = new TouristAttractionActivity();
            LocationActivity oLocationActivity = new LocationActivity();
            _touristAttractions = new List<dynamic>();
            _locationalTouristAttractions = new List<dynamic>();
            _categorizeTouristAttractions = new List<dynamic>();

            _touristAttractions = oTouristAttractionActivity.GetSearchResults(searchKeyword);
            _locationalTouristAttractions = oLocationActivity.GetSearchResults(searchKeyword);
            _categorizeTouristAttractions = oLocationActivity.GetSearchResults(searchKeyword);

            _locationalTouristAttractions = _locationalTouristAttractions.Concat(_categorizeTouristAttractions).ToList<dynamic>();
            _touristAttractions = _touristAttractions.Concat(_locationalTouristAttractions).ToList<dynamic>();

            _data = CommonHelper.GenerateSearchTAJObject(_touristAttractions);

            return Ok(_data);
        }
    }
}
