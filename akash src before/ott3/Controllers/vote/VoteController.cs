using Microsoft.AspNetCore.Mvc;
using ott3.Models;
using ott3.Models.poll;
using ott3.Models.vote;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ott3.Controllers.vote
{
    [Route("vote")]
    public class VoteController : Controller
    {

        [Route("addVote")]
        [HttpPost]
        public CommonResponse AddVote([FromBody] Vote vote)
        {
            vote.uid = null;
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                db.Votes.Add(vote);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        [Route("updateVote")]
        [HttpPost]
        public CommonResponse UpdateVote([FromBody] Vote vote)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                db.Votes.Update(vote);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        

        [Route("giveVote")]
        [HttpPost]
        public CommonResponse GiveVote([FromBody] VoteSummary voteSummary)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                if (db.Votes.Find(voteSummary.voteId) == null)
                    throw new Exception("data not found");
                int userId = Utility.getUserId(); // call method which return current userId
                string userName = Utility.getUserName(); // call method which return current userName
                voteSummary.likeDone = false; voteSummary.dislikeDone = false; voteSummary.shareDone = false;
                db.VoteSummaries.Add(voteSummary);
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
        public CommonResponse AddLikeToVote(int voteId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                if (db.Votes.Find(voteId) == null)
                    throw new Exception("no data found");
                else
                {
                    Vote v = db.Votes.Find(voteId);
                    v.likeCount++;
                    db.Votes.Update(v);
                }
                int userId = Utility.getUserId(); // call method which return current userId
                VoteSummary voteSummary = (from usr in db.VoteSummaries
                            where usr.userId == userId && usr.voteId == voteId
                            select usr).FirstOrDefault();
                if (voteSummary == null)
                    throw new Exception("null encountered");
                voteSummary.likeDone = true;
                db.VoteSummaries.Update(voteSummary);
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
        public CommonResponse AddLDislikeToVote(int voteId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                if (db.Votes.Find(voteId) == null)
                    throw new Exception("no data found");
                else
                {
                    Vote v = db.Votes.Find(voteId);
                    v.dislikeCount++;
                    db.Votes.Update(v);
                }
                int userId = Utility.getUserId(); // call method which return current userId
                VoteSummary voteSummary = (from usr in db.VoteSummaries
                                           where usr.userId == userId && usr.voteId == voteId
                                           select usr).FirstOrDefault();
                if (voteSummary == null)
                    throw new Exception("null encountered"); 
                voteSummary.dislikeDone = true;
                db.VoteSummaries.Update(voteSummary);
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
        public CommonResponse AddShareToVote(int voteId)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                if (db.Votes.Find(voteId) == null)
                    throw new Exception("no data found");
                else
                {
                    Vote v = db.Votes.Find(voteId);
                    v.shareCount++;
                    db.Votes.Update(v);
                }
                int userId = Utility.getUserId(); // call method which return current userId
                VoteSummary voteSummary = (from usr in db.VoteSummaries
                                           where usr.userId == userId && usr.voteId == voteId
                                           select usr).FirstOrDefault();
                if (voteSummary == null)
                    throw new Exception("null encountered"); 
                voteSummary.shareDone = true;
                db.VoteSummaries.Update(voteSummary);
                db.SaveChanges();
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        
        [Route("getVoteById")]
        [HttpGet]
        public CommonResponse GetVoteById(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                response.data = db.Votes.Find(id);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        

        [Route("getAllVotes")]
        [HttpGet]
        public CommonResponse GetAllVote(int pageno, int limit)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                response.data = (from v in db.Votes select v).Skip((pageno - 1) * limit).Take(limit);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        

        [Route("getAllLikesOnVotes")]
        [HttpGet]
        public CommonResponse GetAllLikesOnVote(int pageno, int limit)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                response.data = (from v in db.VoteSummaries select v).Where(x => x.likeDone == true).Skip((pageno - 1) * limit).Take(limit);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        

        [Route("getAllDislikesOnVotes")]
        [HttpGet]
        public CommonResponse GetAllDislikesOnVote(int pageno, int limit)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                response.data = (from v in db.VoteSummaries select v).Where(x => x.dislikeDone == true).Skip((pageno - 1) * limit).Take(limit);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        
        [Route("getAllShareOnVotes")]
        [HttpGet]
        public CommonResponse GetAllShareOnVote(int pageno, int limit)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                response.data = (from v in db.VoteSummaries select v).Where(x => x.shareDone == true).Skip((pageno - 1) * limit).Take(limit);
                response.isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return response;
        }


        
        [Route("deleteVoteById")]
        [HttpGet]
        public CommonResponse DeleteById(int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AppDbContext db = new AppDbContext();
                response.data = db.Votes.Remove(db.Votes.Find(id));
                db.VoteSummaries.RemoveRange(db.VoteSummaries.Where(x => x.voteId == id));
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
