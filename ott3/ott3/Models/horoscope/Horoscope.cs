using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ott3.Models.horoscope
{
    public class Horoscope : BaseEntity
    {
        [Key]
        public int uid { get; set; }
        public int zodiacId { get; set; }
        public int periodTypeId { get; set; }
        public DateTime dateTime { get; set; }
        public bool status { get; set; }
        public int share { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        public Horoscope(int zodiacId, int periodTypeId, DateTime dateTime, int createdBy, bool status, string description)
        {
            this.zodiacId = zodiacId;
            this.periodTypeId = periodTypeId;
            this.dateTime = dateTime;
            this.status = status;
            this.share = 0;
            this.createdBy = createdBy;
            this.updatedBy = createdBy;
            this.description = description;
        }
    }
}