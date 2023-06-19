using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ott3.Models.vote
{
    public class Vote : BaseEntity
    {
        [Key]
        public int? uid { get; set; }
        [StringLength(50)]
        public string votingTitle { get; set; }
        public int amountForVote { get; set; }
        public int votingTypeOfOptions { get; set; }
        [StringLength(50)]
        public string votingPhotoTitle { get; set; }
        public int likeCount { get; set; }
        public int dislikeCount { get; set; }
        public int shareCount { get; set; }
        public int voteCount { get; set; }
        public bool status { get; set; }
        public int votingState { get; set; }   // it is an id of a dropdown
        [StringLength(100)]
        public string description { get; set; }

        [NotMapped]
        public string sessionId { get; set; }

        [NotMapped]
        public string sessionPass { get; set; }

        public Vote(string votingTitle, int amountForVote, int votingTypeOfOptions, string votingPhotoTitle,
            bool status, int votingState, string description)
        {
            this.votingTitle = votingTitle;
            this.amountForVote = amountForVote;
            this.votingTypeOfOptions = votingTypeOfOptions;
            this.votingPhotoTitle = votingPhotoTitle;
            this.likeCount = 0;
            this.dislikeCount = 0;
            this.shareCount = 0;
            this.voteCount = 0;
            this.status = status;
            this.votingState = votingState;
            this.description = description;
        }
    }
}
