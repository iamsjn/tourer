using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TouristAttractionActivity
    {
        #region private objects
        TouristAttractionDA _touristAttractionDA = null;
        ICollection<dynamic> _touristAttractions = null;
        dynamic _touristAttraction = null;
        #endregion

        #region constructor
        public TouristAttractionActivity() { _touristAttractionDA = new TouristAttractionDA(); }
        #endregion

        #region public methods
        #region GetTouristAttractions : IEnumerable<dynamic>
        public IEnumerable<dynamic> GetTouristAttractions(ICollection<int> IDs)
        {
            _touristAttractions = new List<dynamic>();
            _touristAttractions = _touristAttractionDA.GetTouristAttractions(IDs);
            return _touristAttractions;
        }
        #endregion

        #region GetTouristAttractions : IEnumerable<dynamic>
        public IEnumerable<dynamic> GetTouristAttractions()
        {
            _touristAttractions = new List<dynamic>();
            _touristAttractions = _touristAttractionDA.GetTouristAttractions();
            return _touristAttractions;
        }
        #endregion

        #region GetTouristAttraction : dynamic
        public dynamic GetTouristAttraction(int touristAttractionID)
        {
            _touristAttraction = _touristAttractionDA.GetTouristAttraction(touristAttractionID);
            return _touristAttraction;
        }
        #endregion

        #region GetSearchResults : IEnumerable<dynamic>
        public IEnumerable<dynamic> GetSearchResults(string searchKeyword)
        {
            _touristAttractions = new List<dynamic>();
            _touristAttractions = _touristAttractionDA.GetSearchResults(searchKeyword);
            return _touristAttractions;
        }
        #endregion

        #region GetTASuggestions : IEnumerable<dynamic>
        public IEnumerable<dynamic> GetTASuggestions(int touristAttractionID)
        {
            _touristAttractions = new List<dynamic>();

            _touristAttractions = _touristAttractionDA.GetTASuggestions(touristAttractionID);

            return _touristAttractions;
        }
        #endregion
        #endregion
    }
}