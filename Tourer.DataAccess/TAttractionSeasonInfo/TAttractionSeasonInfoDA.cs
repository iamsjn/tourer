using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class TAttractionSeasonInfoDA
    {
        ICollection<int> _touristAttractionIDs = null;
        TourerContext _oTourerContext = null;
        public TAttractionSeasonInfoDA() { _oTourerContext = new TourerContext(); }
        public ICollection<int> GetTAIDs(EnumSeason enumSeason)
        {
            _touristAttractionIDs = new List<int>();
            _touristAttractionIDs = _oTourerContext.TAttractionSeasonInfos.Where(t => t.Season == Convert.ToInt32(enumSeason)).Select(i=>i.TouristAttractionID).Take(CommonHelper.GenerateRandomNumber(2, 8)).ToList();
            return _touristAttractionIDs;
        }
    }
}