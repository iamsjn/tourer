using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tourer.Model;
using Tourer.DataAccess;
using Newtonsoft.Json.Linq;

namespace Tourer.Main
{
    public class DefaultController : ApiController
    {
        User _user = null;
        ICollection<int> _iDs = null;
        IEnumerable<dynamic> _seasonaltouristAttractions = null;
        IEnumerable<dynamic> _locationaltouristAttractions = null;
        IEnumerable<dynamic> _touristAttractions = null;
        JObject _data = null;

        [HttpGet]
        public IHttpActionResult GetSeasonalTouristAttraction()
        {
            TAttractionSeasonInfoActivity oTSeasonActivity = new TAttractionSeasonInfoActivity();
            TouristAttractionActivity oTouristAttractionActivity = new TouristAttractionActivity();
            _iDs = new List<int>();
            _seasonaltouristAttractions = new List<dynamic>();
            //Here we are changing current datetime's year according to our db stored value
            var currentDate = DateTime.Today;
            var modifiedDate = new DateTime(2016, currentDate.Month, currentDate.Day);
            var seasonDate = new DateTime(2016, currentDate.Month, currentDate.Day);

            if ((modifiedDate >= DateTime.Parse("2016/01/01") && modifiedDate <= DateTime.Parse("2016/03/31")) || (modifiedDate >= DateTime.Parse("2016/11/01") && modifiedDate <= DateTime.Parse("2016/12/31")))
                _iDs = oTSeasonActivity.GetTAIDs(EnumSeason.Winter);

            if ((modifiedDate >= DateTime.Parse("2016/04/01") && modifiedDate <= DateTime.Parse("2016/07/31")))
                _iDs = oTSeasonActivity.GetTAIDs(EnumSeason.Summer);

            if ((modifiedDate >= DateTime.Parse("2016/08/01") && modifiedDate <= DateTime.Parse("2016/10/31")))
                _iDs = oTSeasonActivity.GetTAIDs(EnumSeason.Rainy);

            _seasonaltouristAttractions = oTouristAttractionActivity.GetTouristAttractions(_iDs);

            _data = CommonHelper.GenerateSeasonalTAJObject(_seasonaltouristAttractions);

            return Ok(_data);

        }

        [HttpGet]
        public IHttpActionResult GetLocationalTouristAttraction()
        {
            TouristAttractionActivity oTouristAttractionActivity = new TouristAttractionActivity();
            _locationaltouristAttractions = new List<dynamic>();

            _locationaltouristAttractions = oTouristAttractionActivity.GetTouristAttractions();

            _data = CommonHelper.GenerateLocationalTAJObject(_locationaltouristAttractions);

            return Ok(_data);

        }

        [HttpGet]
        public IHttpActionResult GetSeasonalAndLocationalTouristAttraction()
        {
            TouristAttractionActivity oTouristAttractionActivity = new TouristAttractionActivity();
            TAttractionSeasonInfoActivity oTSeasonActivity = new TAttractionSeasonInfoActivity();
            _seasonaltouristAttractions = new List<dynamic>();
            _iDs = new List<int>();
            _locationaltouristAttractions = new List<dynamic>();
            _touristAttractions = new List<dynamic>();
            //Here we are changing current datetime's year according to our db stored value
            var currentDate = DateTime.Today;
            var modifiedDate = new DateTime(2016, currentDate.Month, currentDate.Day);
            var seasonDate = new DateTime(2016, currentDate.Month, currentDate.Day);

            if ((modifiedDate >= DateTime.Parse("2016/01/01") && modifiedDate <= DateTime.Parse("2016/03/31")) || (modifiedDate >= DateTime.Parse("2016/11/01") && modifiedDate <= DateTime.Parse("2016/12/31")))
                _iDs = oTSeasonActivity.GetTAIDs(EnumSeason.Winter);

            if ((modifiedDate >= DateTime.Parse("2016/04/01") && modifiedDate <= DateTime.Parse("2016/07/31")))
                _iDs = oTSeasonActivity.GetTAIDs(EnumSeason.Summer);

            if ((modifiedDate >= DateTime.Parse("2016/08/01") && modifiedDate <= DateTime.Parse("2016/10/31")))
                _iDs = oTSeasonActivity.GetTAIDs(EnumSeason.Rainy);

            _seasonaltouristAttractions = oTouristAttractionActivity.GetTouristAttractions(_iDs);

            _locationaltouristAttractions = oTouristAttractionActivity.GetTouristAttractions();

            _touristAttractions = _locationaltouristAttractions.Concat(_seasonaltouristAttractions).ToList<dynamic>();

            _data = CommonHelper.GenerateLocationalTAJObject(_touristAttractions);

            return Ok(_data);
        }



        [HttpPost]
        public IHttpActionResult GetReviewedTAttraction(int userID)
        {
            TAReviewActivity oTAReviewActivity = new TAReviewActivity();
            _touristAttractions = new List<dynamic>();

            _touristAttractions = oTAReviewActivity.GetReviewedTAttraction(userID);

            _data = CommonHelper.GenerateReviewedTAJObject(_touristAttractions);

            return Ok(_data);

        }

        [HttpPost]
        public IHttpActionResult SignUp(UserAndGCM oUserAndGCM)
        {
            UserActivity oUserActivity = new UserActivity();
            GCMActivity oGCMActivity = new GCMActivity();
            _user = new User();
            _user = oUserActivity.Save(oUserAndGCM.User);

            if (_user != null)
            {
                if (oGCMActivity.Save(oUserAndGCM.GCM, _user.UserID))
                {
                    _data = CommonHelper.GenerateUserJObject(_user);
                    return Ok(_data);
                }
                else
                {
                    _data = CommonHelper.GenerateCommonJObject("Request Invalid", "invalid");
                    return Ok(_data);
                }
            }
            else
            {
                _data = CommonHelper.GenerateCommonJObject("Request Invalid", "invalid");
                return Ok(_data);
            }
        }

        [HttpPost]
        public IHttpActionResult SignIn(UserAndGCM oUserAndGCM)
        {
            UserActivity oUserActivity = new UserActivity();
            GCMActivity oGCMActivity = new GCMActivity();
            _user = new User();

            _user = oUserActivity.IsExist(oUserAndGCM.User);

            if (_user != null)
            {
                if (oGCMActivity.Save(oUserAndGCM.GCM, _user.UserID))
                {
                    _data = CommonHelper.GenerateUserJObject(_user);
                    return Ok(_data);
                }
                else
                {
                    _data = CommonHelper.GenerateCommonJObject("Invalid Email or Password", "invalid");
                    return Ok(_data);
                }
            }
            else
            {
                _data = CommonHelper.GenerateCommonJObject("Invalid Email or Password", "invalid");
                return Ok(_data);
            }
        }
    }
}
