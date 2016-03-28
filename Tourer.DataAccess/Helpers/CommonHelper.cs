using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public static int GenerateRandomNumber(int start, int end)
        {
            Random oRandom = new Random();
            int randomNumber;
            randomNumber = oRandom.Next(start, end);

            return randomNumber;
        }

        #endregion
    }
}