using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tourer.DataAccess;
using Newtonsoft.Json.Linq;
using Tourer.Model;

namespace Tourer.Main.Controllers
{
    public class DetailController : ApiController
    {
        IEnumerable<dynamic> _taSuggestions = null;
        IEnumerable<dynamic> _taPhotos = null;
        ICollection<dynamic> _reviews = null;
        ICollection<dynamic> _childReviews = null;
        ICollection<int> _IDs = null;
        dynamic _touristAttraction = null;
        JObject _data = null;
        double _avgRating = 0.0;
        TAReview _otAReview = null;

        [HttpPost]
        public IHttpActionResult GetDetail(int touristAttractionID)
        {
            TouristAttractionActivity oTouristAttractionActivity = new TouristAttractionActivity();
            TAReviewActivity oTAReviewActivity = new TAReviewActivity();
            TAPhotoActivity oTAPhoto = new TAPhotoActivity();
            _taSuggestions = new List<dynamic>();
            _taPhotos = new List<dynamic>();
            

            _touristAttraction = oTouristAttractionActivity.GetTouristAttraction(touristAttractionID);
            _avgRating = oTAReviewActivity.GetAverageRating(touristAttractionID);
            _taPhotos = oTAPhoto.GetTAPhotos(touristAttractionID);
            _taSuggestions = oTouristAttractionActivity.GetTASuggestions(touristAttractionID);
            _reviews = oTAReviewActivity.GetTAReviews(touristAttractionID);
            _IDs = oTAReviewActivity.GetTAReviewIDs(touristAttractionID);
            _childReviews = oTAReviewActivity.GetTAReviews(_IDs);

            if(_taPhotos == null)
                _taPhotos = new List<dynamic> { new { Photo = string.Empty } };

            if (_taSuggestions == null)
                _taSuggestions = new List<dynamic> { new { ID = string.Empty, Name = string.Empty, Photo = string.Empty, Type = string.Empty } };

            if (_reviews == null)
                _reviews = new List<dynamic> { new { ReviewID = string.Empty, Rating = string.Empty, Review = string.Empty, ReviewDate = string.Empty, UserID = string.Empty, UserName = string.Empty, UserPhoto = string.Empty } };

            if (_childReviews == null)
                _childReviews = new List<dynamic> { new { ParentID = string.Empty, ReviewID = string.Empty, Review = string.Empty, ReviewDate = string.Empty, UserID = string.Empty, UserName = string.Empty, UserPhoto = string.Empty } };

            _data = CommonHelper.GenerateTADetailJObject(_touristAttraction, _avgRating, _taPhotos, _taSuggestions, _reviews, _childReviews);

            return Ok(_data);
        }

        public IHttpActionResult PostReview(TAReview oTAReview)
        {
            _otAReview = new TAReview();
            TAReviewActivity oTAReviewActivity = new TAReviewActivity();

            _otAReview.UserID = oTAReview.UserID;
            _otAReview.TouristAttractionID = oTAReview.TouristAttractionID;
            _otAReview.Rating = oTAReview.Rating;
            _otAReview.Review = oTAReview.Review != null ? oTAReview.Review : string.Empty;

            _otAReview = oTAReviewActivity.Save(_otAReview);

            return Ok(_data);
        }
    }
}
