using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TAPhotoActivity
    {
        #region private objects
        TAPhotoDA _tAPhotoDA = null;
        ICollection<dynamic> _photos = null;
        dynamic _photo = null;
        #endregion

        #region constructor
        public TAPhotoActivity() { _tAPhotoDA = new TAPhotoDA(); }
        #endregion

        #region public methods

        public ICollection<dynamic> GetTAPhotos(int touristAttraction)
        {
            _photos = new List<dynamic>();
            _photos = _tAPhotoDA.GetTAPhotos(touristAttraction);

            return _photos;
        }

        #endregion
    }
}