using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ott3.Models
{
    public class Movie : BaseEntity
    {
        [Key]
        public int uid { get; set; }
        public string movieTitle { get; set; }
        public int genreUid { get; set; }
        public int movieFileUid { get; set; }
        public string maturityRating { get; set; }
        public string description { get; set; }
        public DateTime releaseYear { get; set; }
        public DateTime duration { get; set; }
        public DateTime introStart { get; set; }
        public DateTime introEnd { get; set; }
        public virtual Genre genre { get; set; }
        public virtual MovieFile movieFile { get; set; }
        public virtual ICollection<MoviePoster> moviePosters { get; set; }
        public virtual ICollection<MoviePreview> moviePreviews { get; set; }
        public virtual ICollection<Crew> crews { get; set; }
        public virtual ICollection<AudioLanguage> audioLanguages { get; set; }
        public virtual ICollection<SubtitleLanguage> subtitleLanguages { get; set; }
    }
    [PrimaryKey(nameof(movieUid), nameof(fileUid))]
    public class MoviePoster
    {
        public int movieUid { get; set; }
        public int fileUid { get; set; }
        public BasicFile file { get; set; }
        public Movie movie { get; set; }
    }
    [PrimaryKey(nameof(movieUid), nameof(fileUid))]
    public class MoviePreview
    {
        public int movieUid { get; set; }
        public int fileUid { get; set; }
        public BasicFile file { get; set; }
        public Movie movie { get; set; }
    }
    [PrimaryKey(nameof(movieUid), nameof(fileUid))]
    public class MovieFile
    {
        public int movieUid { get; set; }
        public int fileUid { get; set; }
        public string awslink { get; set; }
        public BasicFile file { get; set; }
        public Movie movie { get; set; }
    }
    [PrimaryKey(nameof(movieUid), nameof(lang))]
    public class AudioLanguage
    {
        public int movieUid { get; set; }
        public string lang { get; set; }
        public Movie movie { get; set; }
    }
    [PrimaryKey(nameof(movieUid), nameof(lang))]
    public class SubtitleLanguage
    {
        public int movieUid { get; set; }
        public string lang { get; set; }
        public Movie movie { get; set; }
    }
}