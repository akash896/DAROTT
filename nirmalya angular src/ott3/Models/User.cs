using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ott3.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int uid { get; set; }
        public string id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phoneno { get; set; }
        public string emailid { get; set; }
        public bool active { get; set; }
        public int admin { get; set; } // 0 => no; 1 =>

        // public ICollection<UserSession> UserSessions { get; }
        // [ForeignKey("Programme")]
        // public int ProgrammeId { get; set; }

        // public virtual Programme Programme { get; set; }    // 1 to 1
        // public virtual StudentAddress StudentAddress { get; set; } // 1 to 1

    }
    public class UserSession : BaseEntity
    {
        [Key]
        public int uid { get; set; }
        public int userUid { get; set; }
        [StringLength(128)]
        public string sessionId { get; set; }
        [StringLength(128)]
        public string sessionPass { get; set; }
        public bool isActive { get; set; }
        // [ForeignKey("uid")]
        public virtual User user { get; set; }

        [NotMapped]
        static Random rd = new Random();
        private string CreateString(int stringLength)
        {
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        public UserSession(int userUid, bool isActive)
        {
            // AppDbContext db = new AppDbContext();
            // this.User = db.Users.Find(user);
            this.userUid = userUid;
            this.isActive = isActive;
            sessionId = CreateString(128);
            sessionPass = CreateString(128);
        }
        /*public UserSession(User user, bool isActive)
        {
            this.User = user;
            this.isActive = isActive;
            sessionId = CreateString(128);
            sessionPass = CreateString(128);
        }*/
        // 0 => no; 1 => 
        // [ForeignKey("Programme")]
        // public int ProgrammeId { get; set; }

        // public virtual Programme Programme { get; set; }    // 1 to 1
        // public virtual StudentAddress StudentAddress { get; set; } // 1 to 1

    }
}