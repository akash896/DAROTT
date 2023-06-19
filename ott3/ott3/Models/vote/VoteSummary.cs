using System.ComponentModel.DataAnnotations;

namespace ott3.Models.vote

{
    public class VoteSummary : BaseEntity
    {
        [Key]
        public int uid { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public int voteId { get; set; }
        public string votedName { get; set; }
        public DateTime dateTime { get; set; }
        public bool likeDone { get; set; }
        public bool dislikeDone { get; set; }
        public bool shareDone { get; set; }

        public VoteSummary(int userId, int voteId, string userName, string votedName, DateTime dateTime)
        {
            this.userId = userId;
            this.voteId = voteId;
            this.userName = userName;
            this.votedName = votedName;
            this.dateTime = dateTime;
            this.likeDone = false;
            this.dislikeDone = false;
            this.shareDone = false;
        }
    }
}
