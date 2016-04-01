using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;
using Newtonsoft.Json.Linq;

namespace Tourer.DataAccess
{
    public class UserActivity
    {
        #region private objects
        User _user = null;
        UserDA _userDA = new UserDA();
        #endregion
        #region constructor
        public UserActivity() { _userDA = new UserDA(); _user = new User(); }
        #endregion
        #region public methods
        #region Save
        public User Save(User oUser)
        {
            try
            {
                _user.Email = oUser.Email;
                _user.FirstName = oUser.FirstName;
                _user.LastName = oUser.LastName;
                _user.Password = oUser.Password;
                SetCommonField(false);

                _user = _userDA.Save(_user);
                return _user;
            }
            catch (Exception)
            {
                _user = null;
                return _user;
            }
        }
        #endregion

        #region IsExist
        public User IsExist(User oUser)
        {
            try
            {
                _user.Email = oUser.Email;
                _user.Password = oUser.Password;

                _user = _userDA.IsExist(_user);
                return _user;
            }
            catch (Exception)
            {
                _user = null;
                return _user;
            }
        }
        #endregion

        #region SetCommonField
        public void SetCommonField(bool isModified)
        {
            if (!isModified)
                _user.CreatedDate = DateTime.Today;
            else
                _user.ModifiedDate = DateTime.Today;
        }  
        #endregion
        #endregion
    }
}