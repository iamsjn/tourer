using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TAReviewDA
    {
        #region private objects
        TourerContext _tourerContext = null;
        ICollection<dynamic> _reviews = null;
        ICollection<dynamic> _touristAttractions = null;
        dynamic _review = null;

        ICollection<int> _IDs = null;
        #endregion

        #region constructor
        public TAReviewDA() { _tourerContext = new TourerContext(); }
        #endregion

        #region public methods

        #region GetAverageRating : double
        public double GetAverageRating(int touristAttractionID)
        {
            double avgRating;
            try
            {
                avgRating = _tourerContext.TAReviews.Where(r => r.TouristAttractionID == touristAttractionID).Average(a => a.Rating);
                return avgRating;
            }
            catch (Exception)
            {
                avgRating = 0.0;
                return avgRating;
            }
        }
        #endregion

        #region GetReviews : ICollection<dynamic>
        public ICollection<dynamic> GetTAReviews(int touristAttractionID)
        {
            _reviews = new List<dynamic>();
            try
            {
                _reviews = _tourerContext.TAReviews.Where(r => r.TouristAttractionID == touristAttractionID).
                    Join(_tourerContext.Users, r => r.UserID, u => u.UserID, (r, u) => new { ReviewID = r.TAReviewID, Rating = r.Rating, Review = r.Review, ReviewDate = r.CreatedDate, UserID = u.UserID, UserName = u.FirstName + " " + u.LastName, UserPhoto = u.Photo }).
                    ToList<dynamic>();

                return _reviews;
            }
            catch (Exception)
            {
                _reviews = null;
                return _reviews;
            }
        }
        #endregion

        #region GetTAReviewIDs : ICollection<int>
        public ICollection<int> GetTAReviewIDs(int touristAttractionID)
        {
            _IDs = new List<int>();
            try
            {
                _IDs = _tourerContext.TAReviews.Where(r => r.TouristAttractionID == touristAttractionID).Select(r => r.TAReviewID).ToList<int>();

                return _IDs;
            }
            catch (Exception)
            {
                _IDs = null;
                return _IDs;
            }
        }
        #endregion

        #region GetTAReviews : ICollection<dynamic>
        public ICollection<dynamic> GetTAReviews(ICollection<int> iDs)
        {
            _reviews = new List<dynamic>();
            try
            {
                foreach (var item in iDs)
                {
                    _review = _tourerContext.TAReviews.Where(r => r.TAReviewID == item).
                                Join(_tourerContext.Users, r => r.UserID, u => u.UserID, (r, u) => new { ParentID = r.ParentID, ReviewID = r.TAReviewID, Review = r.Review, ReviewDate = r.CreatedDate, UserID = u.UserID, UserName = u.FirstName + " " + u.LastName, UserPhoto = u.Photo }).First();
                    _reviews.Add(_review);
                }

                return _reviews;
            }
            catch (Exception)
            {
                _reviews = null;
                return _reviews;
            }
        }
        #endregion

        #region GetReviewedTAttraction : dynamic
        public dynamic GetReviewedTAttraction(int userID)
        {
            try
            {
                _touristAttractions = _tourerContext.TAReviews.Where(r => r.UserID == userID && r.ParentID == 0).
                                        Join(_tourerContext.TouristAttractions, r => r.TouristAttractionID, t => t.TouristAttractionID, (r, t) => new { TAReview = r, TouristAttraction = t }).
                                        Join(_tourerContext.TATypes, t => t.TouristAttraction.TATypeID, ty => ty.TATypeID, (t, ty) => new { ID = t.TouristAttraction.TouristAttractionID, Name = t.TouristAttraction.Name, Photo = t.TouristAttraction.Photo, Type = ty.Name, ReviewID = t.TAReview.TAReviewID, Rating = t.TAReview.Rating, ReviewDate = t.TAReview.CreatedDate }).
                                        Take(CommonHelper.GenerateRandomNumber(10, 10)).OrderByDescending(r => r.ReviewID).
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

        #region Save : TAReview
        public TAReview Save(TAReview oTAReview)
        {
            _tourerContext.TAReviews.Add(oTAReview);
            _tourerContext.SaveChanges();
            oTAReview = _tourerContext.TAReviews.Where(r => r.TAReviewID == oTAReview.TAReviewID).First();
            return oTAReview;
        }
        #endregion

        #endregion
    }
}