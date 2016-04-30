using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Tourer.Model;
using System.ComponentModel;

namespace Tourer.DataAccess
{
    public class CommonHelper
    {
        #region Public Properties

        #region Response : String
        public static Dictionary<string, string> ResponseMessage = new Dictionary<string, string>();
        public static string Response
        {
            get
            {
                return " { " + "'" + ResponseMessage.Keys.FirstOrDefault() + "'" + ":" + "'" + ResponseMessage.Values.FirstOrDefault() + "'" + " } ";
            }
        }
        #endregion

        #endregion

        #region Public Methods

        #region GenerateRandomNumber
        public static int GenerateRandomNumber(int start, int end)
        {
            Random oRandom = new Random();
            int randomNumber;
            randomNumber = oRandom.Next(start, end);

            return randomNumber;
        }
        #endregion

        #region GenerateTASuggestionJObject
        public static JObject GenerateTADetailJObject(dynamic touristAttraction, double avgRating, IEnumerable<dynamic> photos, IEnumerable<dynamic> taSuggestions, IEnumerable<dynamic> reviews, IEnumerable<dynamic> childreviews)
        {
            JObject jObject =
                 new JObject(
                     new JProperty("status", "valid"),
                     new JProperty("avgrating", avgRating),
                     new JProperty("bannerimage", touristAttraction.BannerPhoto),
                     new JProperty("image", touristAttraction.Photo),
                     new JProperty("detail", touristAttraction.Detail),
                     new JProperty("sliding-images",
                                 new JArray(
                                    from p in photos
                                    orderby p.Photo
                                    select new JObject(
                                        new JProperty("image", p.Photo)))),
                    new JProperty("suggestions",
                                 new JArray(
                                    from t in taSuggestions
                                    orderby t.ID
                                    select new JObject(
                                        new JProperty("id", t.ID),
                                        new JProperty("name", t.Name),
                                        new JProperty("image", t.Photo),
                                        new JProperty("type", t.Type)))),
                    new JProperty("reviews",
                                 new JArray(
                                    from r in reviews
                                    orderby r.Rating
                                    select new JObject(
                                        new JProperty("id", r.ReviewID),
                                        new JProperty("rating", r.Rating),
                                        new JProperty("date", r.ReviewDate),
                                        new JProperty("comment", r.Review),
                                        new JProperty("userid", r.UserID),
                                        new JProperty("username", r.UserName),
                                        new JProperty("image", r.UserPhoto),
                                        new JProperty("child-reviews",
                                                     new JArray(
                                                        from c in childreviews
                                                        where c.ParentID == r.ReviewID
                                                        orderby c.ReviewID
                                                        select new JObject(
                                                            new JProperty("id", c.ReviewID),
                                                            new JProperty("date", c.ReviewDate),
                                                            new JProperty("comment", c.Review),
                                                            new JProperty("userid", c.UserID),
                                                            new JProperty("username", c.UserName),
                                                            new JProperty("image", c.UserPhoto))))))));
            return jObject;
        }
        #endregion

        #region GenerateSeasonalTAJObject
        public static JObject GenerateSeasonalTAJObject(IEnumerable<dynamic> touristAttractions)
        {
            if (touristAttractions != null)
            {
                JObject jObject = new JObject(
                      new JProperty("status", "valid"),
                      new JProperty("item",
                          new JArray(
                                from t in touristAttractions
                                orderby t.ID
                                select new JObject(
                                new JProperty("id", t.ID),
                                new JProperty("name", t.Name),
                                new JProperty("photo", t.Photo),
                                new JProperty("type", t.Type)))));
                return jObject;
            }
            else
            {
                JObject jObject = CommonHelper.GenerateCommonJObject("invalid", "No results found!");
                return jObject;
            }
        }
        #endregion

        #region GenerateLocationalTAJObject
        public static JObject GenerateLocationalTAJObject(IEnumerable<dynamic> touristAttractions)
        {
            if (touristAttractions != null)
            {
                JObject jObject = new JObject(
                      new JProperty("status", "valid"),
                      new JProperty("item",
                          new JArray(
                                from t in touristAttractions
                                orderby t.ID
                                select new JObject(
                                new JProperty("id", t.ID),
                                new JProperty("name", t.Name),
                                new JProperty("photo", t.Photo),
                                new JProperty("type", t.Type),
                                new JProperty("location", t.Location)))));
                return jObject;
            }
            else
            {
                JObject jObject = CommonHelper.GenerateCommonJObject("invalid", "No results found!");
                return jObject;
            }
        }
        #endregion

        #region GenerateReviewedTAJObject
        public static JObject GenerateReviewedTAJObject(IEnumerable<dynamic> touristAttractions)
        {
            if (touristAttractions != null)
            {
                JObject jObject = new JObject(
                      new JProperty("status", "valid"),
                      new JProperty("item",
                          new JArray(
                                from t in touristAttractions
                                orderby t.ID
                                select new JObject(
                                new JProperty("id", t.ID),
                                new JProperty("name", t.Name),
                                new JProperty("photo", t.Photo),
                                new JProperty("type", t.Type),
                                new JProperty("rating", t.Rating),
                                new JProperty("date", t.ReviewDate)))));
                return jObject;
            }
            else
            {
                JObject jObject = CommonHelper.GenerateCommonJObject("invalid", "No results found!");
                return jObject;
            }
        }
        #endregion

        #region GenerateSearchTAJObject
        public static JObject GenerateSearchTAJObject(IEnumerable<dynamic> touristAttractions)
        {
            if (touristAttractions != null)
            {
                JObject jObject = new JObject(
                      new JProperty("status", "valid"),
                      new JProperty("item",
                          new JArray(
                                from t in touristAttractions
                                orderby t.ID
                                select new JObject(
                                new JProperty("id", t.ID),
                                new JProperty("name", t.Name),
                                new JProperty("photo", t.Photo),
                                new JProperty("type", t.Type),
                                new JProperty("location", t.Location)))));
                return jObject;
            }
            else
            {
                JObject jObject = CommonHelper.GenerateCommonJObject("invalid", "No results found!");
                return jObject;
            }
        }
        #endregion

        #region GenerateUserJObject
        public static JObject GenerateUserJObject(User oUser)
        {
            if (oUser != null)
            {
                JObject jObject = JObject.FromObject(new { user = new { status = "valid", id = oUser.UserID, email = oUser.Email, firstname = oUser.FirstName, lastname = oUser.LastName, image = oUser.Photo } });
                return jObject;
            }
            else
            {
                JObject jObject = CommonHelper.GenerateCommonJObject("invalid", "No user found!");
                return jObject;
            }
        }
        #endregion

        #region GenerateTAReviewJObject
        public static JObject GenerateTAReviewJObject(TAReview oTAReview)
        {
            if (oTAReview != null)
            {
                JObject jObject = JObject.FromObject(new { user = new { status = "valid", userid = oTAReview.UserID, reviewid = oTAReview.TAReviewID, rating = oTAReview.Rating, review = oTAReview.Review } });
                return jObject;
            }
            else
            {
                JObject jObject = CommonHelper.GenerateCommonJObject("invalid", "No user found!");
                return jObject;
            }
        }
        #endregion

        #region GenerateCommonJObject
        public static JObject GenerateCommonJObject(string status, string message)
        {
            JObject jObject = JObject.FromObject(new { response = new { status = status, message = message } });
            return jObject;
        }
        #endregion

        #endregion
    }
}