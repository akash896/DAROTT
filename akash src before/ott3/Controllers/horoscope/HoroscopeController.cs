using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ott3.Models;
using ott3.Models.horoscope;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ott3.Controllers.horoscope
{
    [Route("horoscope")]
    public class HoroscopeController : Controller
    {

        [Route("addHoroscope")]
        [HttpPost]
        public CommonResponse AddHoroscope(int zodiacId, int periodTypeId, DateTime dateTime, int createdBy, string description)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                Horoscope horoscope = new Horoscope(zodiacId, periodTypeId, dateTime, createdBy, true, description);
                db.Horoscopes.Add(horoscope);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getHoroscopeById")]
        [HttpGet]
        public CommonResponse GetHoroscopeById(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                Horoscope h = db.Horoscopes.Find(id);
                response.data = h;
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getAllHoroscope")]
        [HttpGet]
        public CommonResponse GetAllHoroscope(int pageno, int limit)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                response.data = (from h in db.Horoscopes select h).Skip((pageno - 1) * limit).Take(limit);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getHoroscopeByPeriodType")]
        [HttpGet]
        public CommonResponse GetHoroscopeByPeriodType(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                response.data = db.Horoscopes.Where(x => x.periodTypeId == id);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("deleteHoroscopeById")]
        [HttpGet]
        public CommonResponse DeleteById(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                Horoscope h = db.Horoscopes.Find(id);
                response.data = db.Horoscopes.Remove(h);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("updateHoroscope")]
        [HttpPost]
        public CommonResponse UpdateHoroscope(int uid, int zodiacId, int periodTypeId, DateTime dateTime, int createdBy, string description, 
            bool status, int share)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                Horoscope horoscope = new Horoscope(zodiacId, periodTypeId, dateTime, createdBy, true, description);
                horoscope.uid = uid;
                horoscope.status = status;
                horoscope.share = share;
                db.Horoscopes.Update(horoscope);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }


    }  // class ends
} // namespace ends
