using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourer.Main
{
    public class ResponseStatus
    {
        #region Public Properties

        #region ResponseMessage : Dictionary<string, string>
        private static Dictionary<string, string> responseMessage;
        public static Dictionary<string, string> ResponseMessage
        {
            get
            {
                return responseMessage;
            }
            set
            {
                responseMessage = value;
            }
        }
        #endregion

        #region Response : String
        public static string Response
        {
            get
            {
                return " { " + "'" + ResponseMessage.Keys + "'" + ":" + "'" + ResponseMessage.Values + "'" + " } ";
            }
        }
        #endregion
         
        #endregion


    }
}