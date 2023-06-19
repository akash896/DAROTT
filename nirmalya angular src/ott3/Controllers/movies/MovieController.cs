using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using NuGet.Common;
using ott3.Controllers.users;
using ott3.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ott3.Controllers.movies
{
    [Route("movies")]
    public class MovieController : Controller
    {
        [Route("getGenres")]
        [HttpGet]
        public CommonResponse getGenres()
        {
            CommonResponse resp = new CommonResponse(false, "some error", "");
            try
            {
                // if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                using (var context = new AppDbContext())
                {
                    var data = context.Genres.ToList();
                    resp.isSuccess = true;
                    resp.msg = "got list";
                    resp.data = data;
                }
            }
            catch (Exception ex)
            {
                resp.isSuccess = false;
                resp.msg = ex.Message;
            }
            return resp;
        }
        [Route("getCrewCategories")]
        [HttpGet]
        public CommonResponse getCrewCategories()
        {
            CommonResponse resp = new CommonResponse(false, "some error", "");
            try
            {
                // if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                using (var context = new AppDbContext())
                {
                    var data = context.CrewCategories.ToList();
                    resp.isSuccess = true;
                    resp.msg = "got list";
                    resp.data = data;
                }
            }
            catch (Exception ex)
            {
                resp.isSuccess = false;
                resp.msg = ex.Message;
            }
            return resp;
        }
        [Route("moviesAddModify")]
        [HttpPost]
        public CommonResponse addModify([FromBody] Movie movieIn)
        {
            CommonResponse resp = new CommonResponse(false, "some error", "");
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                using (var context = new AppDbContext())
                {
                    context.Movies.Add(movieIn);
                    context.SaveChanges();
                    // new CookieOptions { }
                    resp.isSuccess = true;
                    resp.msg = "logged in";
                    // resp.data = ses;
                }
            }
            catch (Exception ex)
            {
                resp.isSuccess = false;
                resp.msg = ex.Message;
            }
            return resp;
        }
    }
}