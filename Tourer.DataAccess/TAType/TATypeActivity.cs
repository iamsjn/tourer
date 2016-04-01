using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TATypeActivity
    {
        TATypeDA _tATypeDA = null;
        ICollection<dynamic> _touristAttractions = null;
        public TATypeActivity() { _tATypeDA = new TATypeDA(); }
        public IEnumerable<dynamic> GetSearchResults(string searchKeyword)
        {
            _touristAttractions = new List<dynamic>();
            _touristAttractions = _tATypeDA.GetSearchResults(searchKeyword);
            return _touristAttractions;
        }
    }
}