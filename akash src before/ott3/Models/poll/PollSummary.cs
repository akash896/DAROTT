using System.ComponentModel.DataAnnotations;

namespace ott3.Models.poll

{
    public class PollSummary : BaseEntity
    {
        [Key]
        public int uid { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public int pollId { get; set; }
        public string polledName { get; set; }
        public DateTime dateTime { get; set; }
        public bool likeDone { get; set; }
        public bool dislikeDone { get; set; }
        public bool shareDone { get; set; }
        public bool commentDone { get; set; }
        [StringLength(100)]
        public string comment { get; set; }


        public PollSummary(int userId, int pollId, string userName, string polledName, DateTime dateTime)
        {
            this.userId = userId;
            this.pollId = pollId;
            this.userName = userName;
            this.polledName = polledName;
            this.dateTime = dateTime;
            this.likeDone = false;
            this.dislikeDone = false;
            this.shareDone = false;
            this.commentDone = false;
        }
    }
}
