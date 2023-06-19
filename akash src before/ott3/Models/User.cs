using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ott3.Models
{
    [PrimaryKey(nameof(id))]
    public class User : BaseEntity
    {
        public string id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int admin { get; set; } // 0 => no; 1 => 
        // [ForeignKey("Programme")]
        // public int ProgrammeId { get; set; }

        // public virtual Programme Programme { get; set; }    // 1 to 1
        // public virtual StudentAddress StudentAddress { get; set; } // 1 to 1

    }
    public class UserSession : BaseEntity
    {
        [Key]
        public int uid { get; set; }
        public int userId { get; set; }
        [StringLength(128)]
        public string sessionId { get; set; }
        [StringLength(128)]
        public string sessionPass { get; set; }
        public bool isActive { get; set; }

        public UserSession(int userId, bool isActive)
        {
            this.userId = userId;
            this.isActive = isActive;
            // sessionId = ;
        }
        // 0 => no; 1 => 
        // [ForeignKey("Programme")]
        // public int ProgrammeId { get; set; }

        // public virtual Programme Programme { get; set; }    // 1 to 1
        // public virtual StudentAddress StudentAddress { get; set; } // 1 to 1

    }
}