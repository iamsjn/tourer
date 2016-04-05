using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TAPhotoDA
    {
        #region private objects
        TourerContext _tourerContext = null;
        ICollection<dynamic> _photos = null;
        dynamic _photo = null;
        #endregion

        #region constructor
        public TAPhotoDA() { _tourerContext = new TourerContext(); }
        #endregion

        #region public methods

        #region GetPhotos : ICollection<dynamic>
        public ICollection<dynamic> GetTAPhotos(int touristAttractionID)
        {
            _photos = new List<dynamic>();
            try
            {
                _photos = _tourerContext.TAPhotos.Where(p => p.TouristAttractionID == touristAttractionID).Select(p => new { Photo = p.Photo }).Take(CommonHelper.GenerateRandomNumber(3, 8)).ToList<dynamic>();

                return _photos;
            }
            catch (Exception)
            {
                _photos = null;
                return _photos;
            }
        } 
        #endregion

        #endregion
    }
}