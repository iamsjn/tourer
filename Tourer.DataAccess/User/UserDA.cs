using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourer.Model;

namespace Tourer.DataAccess
{
    public class UserDA
    {
        TourerContext _oTourerContext = null;
        public UserDA() { _oTourerContext = new TourerContext(); }
        public int Save(User oUser)
        {
            _oTourerContext.Users.Add(oUser);
            _oTourerContext.SaveChanges();
            return oUser.UserID;
        }

        public User IsExist(User oUser)
        {
            if (_oTourerContext.Users.Where(u => u.Email == oUser.Email && u.Password == oUser.Password).Any())
            {
                oUser = _oTourerContext.Users.Where(u => u.Email == oUser.Email && u.Password == oUser.Password).First();
                return oUser;
            }
            else
            {
                oUser = null;
                return oUser;
            }
        }
    }
}