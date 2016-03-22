using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using Tourer.Model;

namespace Tourer.Main.Controllers
{
    public class DefaultController : ApiController
    {
        TourerContext _oTourerContext = new TourerContext();

        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IHttpActionResult SignUp(User oUser)
        {
            if (ModelState.IsValid)
            {
                _oTourerContext.Users.Add(oUser);
                _oTourerContext.SaveChanges();

                ResponseStatus.ResponseMessage.Add("response", "Sign up successfully completed.");
                return Ok(ResponseStatus.Response);
            }
            else
            {
                ResponseStatus.ResponseMessage.Add("response", "There was an error. Please try again.");
                return Ok(ResponseStatus.Response);
            }
        }

        [HttpPost]
        public IHttpActionResult SignIn(User oUser, [FromBody] string gCMNo)
        {
            if (ModelState.IsValid && !gCMNo.Equals(string.Empty))
            {
                if(_oTourerContext.Users.Where(x=>x.Email == oUser.Email && x.Password == oUser.Password).Any())
                {
                    FormsAuthentication.SetAuthCookie(oUser.Email, false);
                    return Redirect("api/user");
                }
                else
                {
                    ResponseStatus.ResponseMessage.Add("response", "Sorry, didn't get any information.");
                    return Ok(ResponseStatus.Response);
                }
            }
            else
            {
                ResponseStatus.ResponseMessage.Add("response", "There was an error. Please try again.");
                return Ok(ResponseStatus.Response);
            }
        }
    }
}
