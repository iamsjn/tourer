using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Tourer.Model;

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

        #region GenerateUserJObject
        public static JObject GenerateUserJObject(User oUser)
        {
            JObject jObject = JObject.FromObject(new { user = new { id = oUser.UserID, email = oUser.Email, firstname = oUser.FirstName, lastname = oUser.LastName, status = "valid" } });
            return jObject;
        }
        #endregion

        #region GenerateCommonJObject
        public static JObject GenerateCommonJObject(string message, string status)
        {
            JObject jObject = JObject.FromObject(new { response = new { message = message, status = status } });
            return jObject;
        }
        #endregion

        #endregion
    }
}