using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tourer.Model;

namespace Tourer.Main.Controllers
{
    public class UserController : ApiController
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
        [Route("api/user/userregistration")]
        public IHttpActionResult UserRegistration(User oUser)
        {
            if (ModelState.IsValid)
            {
                _oTourerContext.Users.Add(oUser);
                _oTourerContext.SaveChanges();

                return Ok("{ 'message':'Registration successfully completed' }");
            }
            else
            {
                return Ok("{ 'message' : 'There was an error' }");
            }
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
