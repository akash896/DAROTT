using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using NuGet.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ott3.Controllers.users
{
    [Route("user")]
    public class UserController : Controller
    {
        // dbContext db = new dbContext();
        /*// GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<UserController>
        [Route("login")]
        [HttpPost]
        public void Post(string id, string password)
        {
            var sessionId = Request.Cookies["sessionId"];
            var sessionPass = Request.Cookies["sessionPass"];
            if (sessionId != null && sessionPass != null)
            {

            }

            HttpContext.Response.Cookies.Append("token", "", new CookieOptions { Expires = DateTime.Now.AddDays(30) });
            using (var context = new AppDbContext())
            {
                // Query for all blogs with names starting with B
                var user = from usr in context.Users
                            where usr.id == id && usr.password == password
                            select usr;
                if (user != null )
                {

                }
            }
        }

        /*// PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
