using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TAReviewActivity
    {
        #region private objects
        TAReviewDA _tAReviewDA = null;
        dynamic _tAReview = null;
        ICollection<int> _IDs = null;
        ICollection<dynamic> _reviews = null;
        ICollection<dynamic> _touristAttractions = null;
        #endregion

        #region constructor
        public TAReviewActivity() { _tAReviewDA = new TAReviewDA(); }
        #endregion

        #region public methods

        #region GetAverageRating : double
        public double GetAverageRating(int touristAttractionID)
        {
            double avgRating = _tAReviewDA.GetAverageRating(touristAttractionID);
            return avgRating;
        }
        #endregion

        #region GetReviews : ICollection<dynamic>
        public ICollection<dynamic> GetTAReviews(int touristAttractionID)
        {
            _reviews = new List<dynamic>();
            _reviews = _tAReviewDA.GetTAReviews(touristAttractionID);

            return _reviews;
        }
        #endregion

        #region GetTAReviewIDs : ICollection<int>
        public ICollection<int> GetTAReviewIDs(int touristAttractionID)
        {
            _IDs = new List<int>();
            _IDs = _tAReviewDA.GetTAReviewIDs(touristAttractionID);

            return _IDs;
        }
        #endregion

        #region GetTAReviews : ICollection<dynamic>
        public ICollection<dynamic> GetTAReviews(ICollection<int> iDs)
        {
            _reviews = new List<dynamic>();
            _reviews = _tAReviewDA.GetTAReviews(iDs);

            return _reviews;
        }
        #endregion

        #region GetReviewedTAttraction : ICollection<dynamic>
        public ICollection<dynamic> GetReviewedTAttraction(int userID)
        {
            _touristAttractions = new List<dynamic>();
            _touristAttractions = _tAReviewDA.GetReviewedTAttraction(userID);

            return _reviews;
        }
        #endregion

        #region Save : TAReview
        public TAReview Save(TAReview oTAReview)
        {
            oTAReview = _tAReviewDA.Save(oTAReview);
            return oTAReview;
        }
        #endregion

        #endregion
    }
}