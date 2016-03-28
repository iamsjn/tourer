using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourer.DataAccess
{
    public class TAttractionSeasonInfoActivity
    {
        TAttractionSeasonInfoDA _oTAttractionSeasonInfoDA = null;
        ICollection<int> _touristAttractionIDs = null;
        public TAttractionSeasonInfoActivity() { _oTAttractionSeasonInfoDA = new TAttractionSeasonInfoDA(); }
        public ICollection<int> GetTAIDs(EnumSeason enumSeason)
        {
            _touristAttractionIDs = new List<int>();
            _touristAttractionIDs = _oTAttractionSeasonInfoDA.GetTAIDs(enumSeason);
            return _touristAttractionIDs;
        }
    }
}