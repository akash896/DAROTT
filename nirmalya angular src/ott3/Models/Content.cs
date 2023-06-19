using System.ComponentModel.DataAnnotations;

namespace ott3.Models
{
    public class Genre
    {
        [Key]
        public int uid { get; set; }
        public string label { get; set; }
    }
    public class Crew
    {
        [Key]
        public int uid { get; set; }
        public int categoryUid { get; set; }
        public string castingName { get; set; }
        public string characterName { get; set; }
        public int movieUid { get; set; }
        public virtual CrewCategory category { get; set; }
        public Movie movie { get; set; }
    }
    public class CrewCategory
    {
        [Key]
        public int uid { get; set; }
        public string label { get; set; }
    }
}
