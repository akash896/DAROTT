using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ott3.Models.poll
{
    public class Poll : BaseEntity
    {
        [Key]
        public int? uid { get; set; }
        [StringLength(50)]
        public string pollTitle { get; set; }
        public int amountForPoll { get; set; }
        public int pollTypeOfOptions { get; set; }
        [StringLength(50)]
        public string pollPhotoTitle { get; set; }
        public int likeCount { get; set; }
        public int dislikeCount { get; set; }
        public int shareCount { get; set; }
        public int commentCount { get; set; }
        public bool status { get; set; }
        public int pollState { get; set; }   // it is an id of a dropdown
        [StringLength(100)]
        public string description { get; set; }

        [NotMapped]
        public string sessionId { get; set; }

        [NotMapped]
        public string sessionPass { get; set; }



        public Poll(string pollTitle, int amountForPoll, int pollTypeOfOptions, string pollPhotoTitle,
            bool status, int pollState, string description)
        {
            this.pollTitle = pollTitle;
            this.amountForPoll = amountForPoll;
            this.pollTypeOfOptions = pollTypeOfOptions;
            this.pollPhotoTitle = pollPhotoTitle;
            this.likeCount = 0;
            this.dislikeCount = 0;
            this.shareCount = 0;
            this.commentCount = 0;
            this.status = status;
            this.pollState = pollState;
            this.description = description;
        }
    }
}
