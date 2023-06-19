using Microsoft.AspNetCore.Mvc;
using ott3.Controllers.users;
using ott3.Models;
using ott3.Models.poll;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ott3.Controllers.poll
{
    [Route("poll")]
    public class PollController : Controller
    {

        [Route("addPoll")]
        [HttpPost]
        public CommonResponse AddPoll([FromBody] Poll poll)
        {
            poll.uid = null;
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                db.Polls.Add(poll);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("updatePoll")]
        [HttpPost]
        public CommonResponse UpdatePoll([FromBody] Poll poll)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                db.Polls.Update(poll);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        

        [Route("givePoll")]
        [HttpPost]
        public CommonResponse GivePoll([FromBody] PollSummary pollSummary)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                if (db.Polls.Find(pollSummary.pollId) == null)
                    throw new Exception("data not found");
                User u = UserController.GetUser(HttpContext);
                int userId = u.uid; // call method which return current userId
                string userName = u.id; // call method which return current userName
                pollSummary.likeDone = false; pollSummary.dislikeDone = false; pollSummary.shareDone = false;
                pollSummary.commentDone = false;

                db.PollSummaries.Add(pollSummary);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        
        [Route("addLike")]
        [HttpGet]
        public CommonResponse AddLikeToPoll(int pollId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                if (db.Polls.Find(pollId) == null)
                    throw new Exception("no data found");
                else
                {
                    Poll p = db.Polls.Find(pollId);
                    p.likeCount++;
                    db.Polls.Update(p);
                }
                User u = UserController.GetUser(HttpContext);
                int userId = u.uid; // call method which return current userId
                PollSummary pollSummary = (from usr in db.PollSummaries
                                           where usr.userId == userId && usr.pollId == pollId
                            select usr).FirstOrDefault();
                if (pollSummary == null)
                    throw new Exception("null encountered");
                pollSummary.likeDone = true;
                db.PollSummaries.Update(pollSummary);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        

        [Route("addDislike")]
        [HttpGet]
        public CommonResponse AddLDislikeToPoll(int pollId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                if (db.Polls.Find(pollId) == null)
                    throw new Exception("no data found");
                else
                {
                    Poll p = db.Polls.Find(pollId);
                    p.dislikeCount++;
                    db.Polls.Update(p);
                }
                User u = UserController.GetUser(HttpContext);
                int userId = u.uid; // call method which return current userId
                PollSummary pollSummary = (from usr in db.PollSummaries
                                           where usr.userId == userId && usr.pollId == pollId
                                           select usr).FirstOrDefault();
                if (pollSummary == null)
                    throw new Exception("null encountered"); 
                pollSummary.dislikeDone = true;
                db.PollSummaries.Update(pollSummary);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        

        [Route("addShare")]
        [HttpGet]
        public CommonResponse AddShareToPoll(int pollId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                if (db.Polls.Find(pollId) == null)
                    throw new Exception("no data found");
                else
                {
                    Poll p = db.Polls.Find(pollId);
                    p.shareCount++;
                    db.Polls.Update(p);
                }
                User u = UserController.GetUser(HttpContext);
                int userId = u.uid; // call method which return current userId
                PollSummary pollSummary = (from usr in db.PollSummaries
                                           where usr.userId == userId && usr.pollId == pollId
                                           select usr).FirstOrDefault();
                if (pollSummary == null)
                    throw new Exception("null encountered"); 
                pollSummary.shareDone = true;
                db.PollSummaries.Update(pollSummary);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("addView")]
        [HttpGet]
        public CommonResponse AddViewToPoll(int pollId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                if (db.Polls.Find(pollId) == null)
                    throw new Exception("no data found");
                else
                {
                    Poll p = db.Polls.Find(pollId);
                    p.viewCount++;
                    db.Polls.Update(p);
                }
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("addComment")]
        [HttpPost]
        public CommonResponse AddCommentToPoll([FromBody] PollSummary ps)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                if (db.Polls.Find(ps.pollId) == null)
                    throw new Exception("no data found");
                else
                {
                    Poll p = db.Polls.Find(ps.pollId);
                    p.commentCount++;
                    db.Polls.Update(p);
                }
                User u = UserController.GetUser(HttpContext);
                int userId = u.uid; // call method which return current userId
                PollSummary pollSummary = (from usr in db.PollSummaries
                                           where usr.userId == userId && usr.pollId == ps.pollId
                                           select usr).FirstOrDefault();
                if (pollSummary == null)
                    throw new Exception("null encountered");
                pollSummary.commentDone = true;
                pollSummary.comment = ps.comment;
                db.PollSummaries.Update(pollSummary);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }



        [Route("getPollById")]
        [HttpGet]
        public CommonResponse GetPollById(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                response.data = db.Polls.Find(id);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        

        [Route("getAllPoll")]
        [HttpGet]
        public CommonResponse GetAllPoll(int pageno, int limit)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                response.data = (from v in db.Polls select v).Skip((pageno - 1) * limit).Take(limit);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        

        [Route("getAllLikesOnPolls")]
        [HttpGet]
        public CommonResponse GetAllLikesOnPoll(int pageno, int limit)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                response.data = (from v in db.PollSummaries select v).Where(x => x.likeDone == true).Skip((pageno - 1) * limit).Take(limit);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        

        [Route("getAllDislikesOnPolls")]
        [HttpGet]
        public CommonResponse GetAllDislikesOnPoll(int pageno, int limit)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                response.data = (from v in db.PollSummaries select v).Where(x => x.dislikeDone == true).Skip((pageno - 1) * limit).Take(limit);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        
        [Route("getAllShareOnPolls")]
        [HttpGet]
        public CommonResponse GetAllShareOnPoll(int pageno, int limit)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                response.data = (from v in db.PollSummaries select v).Where(x => x.shareDone == true).Skip((pageno - 1) * limit).Take(limit);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getAllCommentOnPolls")]
        [HttpGet]
        public CommonResponse GetAllCommentOnPoll(int pageno, int limit)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                response.data = (from v in db.PollSummaries select v).Where(x => x.commentDone == true).Skip((pageno - 1) * limit).Take(limit);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }


        [Route("deletePollById")]
        [HttpGet]
        public CommonResponse DeleteById(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                    db.Polls.Remove(db.Polls.Find(id));
                db.PollSummaries.RemoveRange(db.PollSummaries.Where(x => x.pollId == id));
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getPollSummaryById")]
        [HttpGet]
        public CommonResponse GetPollSummaryById(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                response.data = db.PollSummaries.Where(x => x.pollId == id).ToList();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getPollSummaryByLikeDone")]
        [HttpGet]
        public CommonResponse GetPollSummaryByLikeDone(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                response.data = (from usr in db.PollSummaries
                                 where usr.pollId == id && usr.likeDone == true
                                 select usr).ToList();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getPollSummaryByDislikeDone")]
        [HttpGet]
        public CommonResponse GetPollSummaryByDislikeDone(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                response.data = (from usr in db.PollSummaries
                                 where usr.pollId == id && usr.dislikeDone == true
                                 select usr).ToList();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getPollSummaryByShareDone")]
        [HttpGet]
        public CommonResponse GetPollSummaryByShareDone(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                response.data = (from usr in db.PollSummaries
                                 where usr.pollId == id && usr.shareDone == true
                                 select usr).ToList();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("getPollSummaryByCommentDone")]
        [HttpGet]
        public CommonResponse GetPollSummaryByCommentDone(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                response.data = (from usr in db.PollSummaries
                                 where usr.pollId == id && usr.commentDone == true
                                 select usr).ToList();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("deleteVoteSummaryById")]
        [HttpGet]
        public CommonResponse DeleteSummaryById(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                if (!UserController.CheckLogin(HttpContext, 1)) throw new Exception("wrong credentioals");
                AppDbContext db = new AppDbContext();
                db.VoteSummaries.Remove(db.VoteSummaries.Find(id));
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }




    } // class ends
} // namespace ends
