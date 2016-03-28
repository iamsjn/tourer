using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class GCMDA
    {
        TourerContext _oTourerContext = null;
        public GCMDA() { _oTourerContext = new TourerContext(); }
        public void Save(GCM oGCM)
        {
            if (_oTourerContext.GCMs.Where(g => g.GCMNo == oGCM.GCMNo && g.UserID == oGCM.UserID).Any())
                return;
            else
            {
                _oTourerContext.GCMs.Add(oGCM);
                _oTourerContext.SaveChanges();
            }
        }
    }
}