using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ott3.Models;
using ott3.Models.eventPage;
using ott3.Models.horoscope;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ott3.Controllers.eventPage
{
    [Route("eventPage")]
    public class HoroscopeController : Controller
    {

        [Route("addEventPage")]
        [HttpPost]
        public CommonResponse AddEventPage(int eventTypeId, DateTime dateTime, int createdBy, string description)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                EventPage eventPage = new EventPage(eventTypeId, dateTime, createdBy, true, description);
                db.EventPages.Add(eventPage);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getEventPageById")]
        [HttpGet]
        public CommonResponse GetEventPageById(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                EventPage h = db.EventPages.Find(id);
                response.data = h;
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getAllEventPage")]
        [HttpGet]
        public CommonResponse GetAllEventPage(int pageno, int limit)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                response.data = (from h in db.EventPages select h).Skip((pageno - 1) * limit).Take(limit);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getEventPageByType")]
        [HttpGet]
        public CommonResponse GetEventPageByType(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                response.data = db.EventPages.Where(x => x.eventTypeId == id);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("deleteEventPageById")]
        [HttpGet]
        public CommonResponse deleteEventPageById(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                EventPage h = db.EventPages.Find(id);
                response.data = db.EventPages.Remove(h);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("updateEventPage")]
        [HttpPost]
        public CommonResponse UpdateEventPage(int uid, int eventTypeId, DateTime dateTime, int createdBy, string description,
            bool status, int share)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                EventPage eventPage = new EventPage(eventTypeId, dateTime, createdBy, true, description);
                eventPage.uid = uid;
                eventPage.status = status;
                eventPage.share = share;
                db.EventPages.Update(eventPage);
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
