using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class GCMActivity
    {
        GCM _GCM = null;
        GCMDA _GCMDA = new GCMDA();
        public GCMActivity() { _GCM = new GCM(); }
        public bool Save(GCM oGCM, int userID)
        {
            try
            {
                _GCM.GCMNo = oGCM.GCMNo;
                _GCM.UserID = userID;
                SetCommonField(false);

                _GCMDA.Save(_GCM);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void SetCommonField(bool isModified)
        {
            if (!isModified)
                _GCM.CreatedDate = DateTime.Today;
            else
                _GCM.ModifiedDate = DateTime.Today;
        }
    }
}