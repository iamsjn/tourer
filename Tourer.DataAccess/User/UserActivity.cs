using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class UserActivity
    {
        User _User = null;
        UserDA _UserDA = new UserDA();
        public UserActivity() { _User = new User(); }
        public int Save(User ouser)
        {
            int userID;
            try
            {
                _User.Email = ouser.Email;
                _User.FirstName = ouser.FirstName;
                _User.LastName = ouser.LastName;
                _User.Password = ouser.Password;
                SetCommonField(false);

                userID =  _UserDA.Save(_User);
                return userID;
            }
            catch (Exception)
            {
                userID = 0;
                return userID;
            }
        }

        public User IsExist(User ouser)
        {
            try
            {
                _User.Email = ouser.Email;
                _User.Password = ouser.Password;

                ouser = _UserDA.IsExist(_User);
                return ouser;
            }
            catch (Exception)
            {
                ouser = null;
                return ouser;
            }
        }

        public void SetCommonField(bool isModified)
        {
            if (!isModified)
                _User.CreatedDate = DateTime.Today;
            else
                _User.ModifiedDate = DateTime.Today;
        }
    }
}