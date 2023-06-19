using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using NuGet.Common;
using ott3.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ott3.Controllers.users
{
    [Route("user")]
    public class UserController : Controller
    {
        [Route("login")]
        [HttpPost]
        public CommonResponse Post([FromBody] User userIn)
        {
            CommonResponse resp = new CommonResponse(false, "some error", "");
            try
            {
                AppDbContext db = new AppDbContext();
                var sessionId = HttpContext.Request.Cookies["sessionId"];
                var sessionPass = HttpContext.Request.Cookies["sessionPass"];
                // string cookieValueFromContext = HttpContext.Request.Cookies["sessionId"];
                if (!string.IsNullOrEmpty(sessionId) && !string.IsNullOrEmpty(sessionPass))
                {
                    var ses = db.UserSessions.Where( x => x.sessionId == sessionId && x.sessionPass == sessionPass).FirstOrDefault();
                    if (ses != null)
                    {
                        resp.isSuccess = true;
                        resp.msg = "already logged in";
                        resp.data = ses;
                        return resp;
                    }
                }
                using (var context = new AppDbContext())
                {
                    // Query for all blogs with names starting with B
                    var user = (from usr in context.Users
                                where usr.id == userIn.id && usr.password == userIn.password
                                select usr).FirstOrDefault();
                    if (user != null)
                    {
                        UserSession ses = new UserSession(user.uid, true);
                        db.UserSessions.Add(ses);
                        db.SaveChanges();
                        var cookieOptions = new CookieOptions
                        {
                            Secure = true,
                            HttpOnly = true,
                            SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                            Expires = DateTimeOffset.UtcNow.AddDays(1).AddDays(60),
                        };
                        HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, PUT, POST, DELETE, OPTIONS");
                        HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
                        HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                        HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, Content-Type, Accept");
                        HttpContext.Response.Cookies.Append("sessionId", ses.sessionId, cookieOptions);
                        HttpContext.Response.Cookies.Append("sessionPass", ses.sessionPass, cookieOptions);
                        // new CookieOptions { }
                        resp.isSuccess = true;
                        resp.msg = "logged in";
                        resp.data = ses;

                    } else
                    {
                        throw new Exception("wrong credentioals");
                    }
                }
            }
            catch (Exception ex)
            {
                resp.isSuccess = false;
                resp.msg = ex.Message;
            }
            return resp;
        }
        // admin
        [Route("checklogin")]
        [HttpPost]
        public CommonResponse CheckLogin([FromBody] User userIn)
        {
            CommonResponse resp = new CommonResponse(false, "some error", "");
            try
            {
                AppDbContext db = new AppDbContext();
                var sessionId = HttpContext.Request.Cookies["sessionId"];
                var sessionPass = HttpContext.Request.Cookies["sessionPass"];
                if (!string.IsNullOrEmpty(sessionId) && !string.IsNullOrEmpty(sessionPass))
                {
                    var sess = db.UserSessions.Where(x => x.sessionId == sessionId && x.sessionPass == sessionPass && x.user.admin >= userIn.admin).FirstOrDefault();
                    if (sess != null)
                    {
                        resp.isSuccess = true;
                        resp.msg = "valid user";
                        return resp;
                    }
                    throw new Exception("wrong credentioals");
                }
            }
            catch (Exception ex)
            {
                resp.isSuccess = false;
                resp.msg = ex.Message;
            }
            return resp;
        }
        [Route("logout")]
        [HttpPost]
        public CommonResponse Logout([FromBody] User userIn)
        {
            CommonResponse resp = new CommonResponse(false, "some error", "");
            try
            {
                AppDbContext db = new AppDbContext();
                var sessionId = HttpContext.Request.Cookies["sessionId"];
                var sessionPass = HttpContext.Request.Cookies["sessionPass"];
                if (!string.IsNullOrEmpty(sessionId) && !string.IsNullOrEmpty(sessionPass))
                {
                    var sess = db.UserSessions.Where(x => x.sessionId == sessionId && x.sessionPass == sessionPass).FirstOrDefault();
                    if (sess != null)
                    {
                        db.UserSessions.Remove(sess);
                        db.SaveChanges();
                        resp.isSuccess = true;
                        resp.msg = "logged out";
                        return resp;
                    }
                    throw new Exception("wrong credentioals");
                }
            }
            catch (Exception ex)
            {
                resp.isSuccess = false;
                resp.msg = ex.Message;
            }
            return resp;
        }
        [Route("get")]
        [HttpPost]
        public CommonResponse Get([FromBody] User userIn)
        {
            CommonResponse resp = new CommonResponse(false, "some error", "");
            try
            {
                AppDbContext db = new AppDbContext();
                var sessionId = HttpContext.Request.Cookies["sessionId"];
                var sessionPass = HttpContext.Request.Cookies["sessionPass"];
                if (!string.IsNullOrEmpty(sessionId) && !string.IsNullOrEmpty(sessionPass))
                {
                    var sess = db.UserSessions.Where(x => x.sessionId == sessionId && x.sessionPass == sessionPass).Include(x => x.user).FirstOrDefault();
                    if (sess != null)
                    {   sess.user.password = "";
                        resp.isSuccess = true;
                        resp.msg = "got data";
                        resp.data = sess.user;
                        return resp;
                    }
                    throw new Exception("wrong credentioals");
                }
            }
            catch (Exception ex)
            {
                resp.isSuccess = false;
                resp.msg = ex.Message;
            }
            return resp;
        }

        [Route("testAdd")]
        [HttpPost]
        public CommonResponse testAdd([FromBody] User userIn)
        {
            CommonResponse resp = new CommonResponse(false, "some error", "");
            try
            {
                var t = HttpContext.Request.Cookies["test"];

                var cookieOptions = new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None
                };
                HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, PUT, POST, DELETE, OPTIONS");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, Content-Type, Accept");
                HttpContext.Response.Cookies.Append("test", "hi", cookieOptions);
            }
            catch (Exception ex)
            {
                resp.isSuccess = false;
                resp.msg = ex.Message;
            }
            return resp;
        }
        public static bool CheckLogin(HttpContext context, int isadmin)
        {
            try
            {
                AppDbContext db = new AppDbContext();
                var sessionId = context.Request.Cookies["sessionId"];
                var sessionPass = context.Request.Cookies["sessionPass"];
                if (!string.IsNullOrEmpty(sessionId) && !string.IsNullOrEmpty(sessionPass))
                {
                    var sess = db.UserSessions.Where(x => x.sessionId == sessionId && x.sessionPass == sessionPass && x.user.admin >= isadmin).FirstOrDefault();
                    if (sess != null)
                    {
                        return true;
                    }
                    throw new Exception("wrong credentioals");
                }
            }
            catch (Exception ex)
            {
            }
            return false;
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
        public static User GetUser(HttpContext context)
        {
            try
            {
                AppDbContext db = new AppDbContext();
                var sessionId = context.Request.Cookies["sessionId"];
                var sessionPass = context.Request.Cookies["sessionPass"];
                if (!string.IsNullOrEmpty(sessionId) && !string.IsNullOrEmpty(sessionPass))
                {
                    var sess = db.UserSessions.Where(x => x.sessionId == sessionId && x.sessionPass == sessionPass).FirstOrDefault();
                    if (sess != null)
                    {
                        return sess.user;
                    }
                    throw new Exception("wrong credentioals");
                }
            }
            catch (Exception ex)
            {
            }
            User t = new User();
            t.uid = -1;
            t.id = "unknown";
            return t;
        }
    }
}