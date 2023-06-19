using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ott3.Models.eventPage
{
    public class EventPage : BaseEntity
    {
        [Key]
        public int uid { get; set; }
        public int eventTypeId { get; set; }
        public DateTime dateTime { get; set; }
        public bool status { get; set; }
        public int share { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        public EventPage(int eventTypeId, DateTime dateTime, int createdBy, bool status, string description)
        {
            this.eventTypeId = eventTypeId;
            this.dateTime = dateTime;
            this.status = status;
            this.share = 0;
            this.createdBy = createdBy;
            this.updatedBy = createdBy;
            this.description = description;
        }
    }
}