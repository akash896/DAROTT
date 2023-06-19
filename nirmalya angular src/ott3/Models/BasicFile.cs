using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ott3.Models
{
    public class BasicFile : BaseEntity
    {
        [Key]
        public int uid { get; set; }
        public string name { get; set; }
        public string ext { get; set; }
        public long size { get; set; }
        public string url { get; set; }
        [NotMapped]
        public string status { get; set; }
        [NotMapped]
        public string response { get; set; }
        // [ForeignKey("Programme")]
        // public int ProgrammeId { get; set; }

        // public virtual Programme Programme { get; set; }    // 1 to 1
        // public virtual StudentAddress StudentAddress { get; set; } // 1 to 1

    }
}