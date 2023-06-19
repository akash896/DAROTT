using Microsoft.AspNetCore.Mvc;
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
                AppDbContext db = new AppDbContext();
                if (db.Polls.Find(pollSummary.pollId) == null)
                    throw new Exception("data not found");
                int userId = Utility.getUserId(); // call method which return current userId
                string userName = Utility.getUserName(); // call method which return current userName
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
                AppDbContext db = new AppDbContext();
                if (db.Polls.Find(pollId) == null)
                    throw new Exception("no data found");
                else
                {
                    Poll p = db.Polls.Find(pollId);
                    p.likeCount++;
                    db.Polls.Update(p);
                }
                int userId = Utility.getUserId(); // call method which return current userId
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
                AppDbContext db = new AppDbContext();
                if (db.Polls.Find(pollId) == null)
                    throw new Exception("no data found");
                else
                {
                    Poll p = db.Polls.Find(pollId);
                    p.dislikeCount++;
                    db.Polls.Update(p);
                }
                int userId = Utility.getUserId(); // call method which return current userId
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
                AppDbContext db = new AppDbContext();
                if (db.Polls.Find(pollId) == null)
                    throw new Exception("no data found");
                else
                {
                    Poll p = db.Polls.Find(pollId);
                    p.shareCount++;
                    db.Polls.Update(p);
                }
                int userId = Utility.getUserId(); // call method which return current userId
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

        [Route("addComment")]
        [HttpPost]
        public CommonResponse AddCommentToPoll([FromBody] PollSummary ps)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                if (db.Polls.Find(ps.pollId) == null)
                    throw new Exception("no data found");
                else
                {
                    Poll p = db.Polls.Find(ps.pollId);
                    p.commentCount++;
                    db.Polls.Update(p);
                }
                int userId = Utility.getUserId(); // call method which return current userId
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




    } // class ends
} // namespace ends
