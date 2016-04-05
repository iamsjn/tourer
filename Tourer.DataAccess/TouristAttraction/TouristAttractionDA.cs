using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TouristAttractionDA
    {
        #region private objects
        TourerContext _tourerContext = null;
        ICollection<dynamic> _mainlocationtouristAttractions = null;
        ICollection<dynamic> _parentlocationtouristAttractions = null;
        ICollection<dynamic> _touristAttractions = null;
        ICollection<int> _locationIDs = null;
        dynamic _touristAttraction = null;
        #endregion

        #region constructor
        public TouristAttractionDA() { _tourerContext = new TourerContext(); }
        #endregion

        #region public methods
        #region GetTouristAttractions : ICollection<dynamic>
        public ICollection<dynamic> GetTouristAttractions(ICollection<int> IDs)
        {
            _touristAttractions = new List<dynamic>();
            try
            {
                foreach (int id in IDs)
                {
                    _touristAttraction = _tourerContext.TouristAttractions.Where(t => t.TouristAttractionID == id).
                                        Join(_tourerContext.TATypes, t => t.TATypeID, ty => ty.TATypeID, (t, ty) => new { ID = t.TouristAttractionID, Name = t.Name, Photo = t.Photo, Type = ty.Name }).
                                        First();

                    _touristAttractions.Add(_touristAttraction);
                }
                return _touristAttractions;
            }
            catch (Exception)
            {
                _touristAttractions = null;
                return _touristAttractions;
            }
        }
        #endregion

        #region GetTouristAttractions : ICollection<dynamic>
        public ICollection<dynamic> GetTouristAttractions()
        {
            _touristAttractions = new List<dynamic>();
            try
            {
                _touristAttractions = _tourerContext.TouristAttractions.
                                        Join(_tourerContext.Locations, t=> t.LocationID, l=>l.LocationID, (t,l)=>new { TouristAttraction = t, Location = l }).
                                        Join(_tourerContext.TATypes, t => t.TouristAttraction.TATypeID, ty => ty.TATypeID, (t, ty) => new { ID = t.TouristAttraction.TouristAttractionID, Name = t.TouristAttraction.Name, Photo = t.TouristAttraction.Photo, Type = ty.Name, Location = t.Location.Name }).
                                        Take(CommonHelper.GenerateRandomNumber(2, 8)).ToList<dynamic>();
                return _touristAttractions;
            }
            catch (Exception)
            {
                _touristAttractions = null;
                return _touristAttractions;
            }
        }
        #endregion

        #region GetTouristAttraction : dynamic
        public dynamic GetTouristAttraction(int touristAttractionID)
        {
            try
            {
                _touristAttraction = _tourerContext.TouristAttractions.Where(t => t.TouristAttractionID == touristAttractionID).
                                        Join(_tourerContext.TADetails, t => t.TouristAttractionID, d => d.TouristAttractionID, (t, d) => new { Photo = t.Photo, BannerPhoto = t.BannerPhoto, Detail = d.Detail }).First();
                return _touristAttraction;
            }
            catch (Exception)
            {
                _touristAttraction = null;
                return _touristAttraction;
            }
        }
        #endregion

        #region GetSearchResults : ICollection<dynamic>
        public ICollection<dynamic> GetSearchResults(string searchKeyword)
        {
            _touristAttractions = new List<dynamic>();
            try
            {
                _touristAttractions = _tourerContext.TouristAttractions.Where(t => t.Name.StartsWith(searchKeyword) || t.Name.Contains(searchKeyword) || t.Name.EndsWith(searchKeyword)).
                                        Join(_tourerContext.TATypes, t => t.TATypeID, x => x.TATypeID, (t, x) => new { TouristAttraction = t, TAType = x, }).
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
        #endregion

        #region GetTASuggestions : IEnumerable<dynamic>
        public ICollection<dynamic> GetTASuggestions(int touristAttractionID)
        {
            try
            {
                _touristAttractions = new List<dynamic>();
                _mainlocationtouristAttractions = new List<dynamic>();
                _parentlocationtouristAttractions = new List<dynamic>();
                _locationIDs = new List<int>();

                int locationID = _tourerContext.TouristAttractions.Where(t => t.TouristAttractionID == touristAttractionID).Select(l => l.LocationID).First();
                var parentID = _tourerContext.Locations.Where(l => l.LocationID == locationID).Select(p => p.ParentID).First();

                _mainlocationtouristAttractions = _tourerContext.TouristAttractions.Where(t => t.LocationID == locationID && t.TouristAttractionID != touristAttractionID).
                    Join(_tourerContext.TATypes, t => t.TATypeID, ty => ty.TATypeID, (t, ty) => new { ID = t.TouristAttractionID, Name = t.Name, Photo = t.Photo, Type = ty.Name }).
                    ToList<dynamic>();

                if (parentID != null)
                {
                    _parentlocationtouristAttractions = _tourerContext.TouristAttractions.Where(t => t.LocationID == parentID && t.TouristAttractionID != touristAttractionID).
                                            Join(_tourerContext.TATypes, t => t.TATypeID, ty => ty.TATypeID, (t, ty) => new { ID = t.TouristAttractionID, Name = t.Name, Photo = t.Photo, Type = ty.Name }).
                                            ToList<dynamic>();

                    _locationIDs = _tourerContext.Locations.Where(l => l.ParentID == parentID && l.LocationID != locationID).Select(i => i.LocationID).Take(CommonHelper.GenerateRandomNumber(2, 8)).ToList<int>();

                    foreach (int item in _locationIDs)
                    {
                        _touristAttraction = _tourerContext.TouristAttractions.Where(t => t.LocationID == item).
                                                Join(_tourerContext.TATypes, t => t.TATypeID, ty => ty.TATypeID, (t, ty) => new { ID = t.TouristAttractionID, Name = t.Name, Photo = t.Photo, Type = ty.Name }).
                                                First();
                        _touristAttractions.Add(_touristAttraction);
                    }
                }

                _mainlocationtouristAttractions = _mainlocationtouristAttractions.Concat(_parentlocationtouristAttractions).ToList<dynamic>();
                _touristAttractions = _touristAttractions.Concat(_mainlocationtouristAttractions).ToList<dynamic>();

                return _touristAttractions;
            }
            catch (Exception)
            {
                _touristAttractions = null;
                return _touristAttractions;
            }
        }
        #endregion
        #endregion
    }
}