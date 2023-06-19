using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace ott3.Models
{
    public class BaseEntity
    {
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }

    }
}
