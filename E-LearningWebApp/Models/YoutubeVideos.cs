using System.ComponentModel.DataAnnotations;

namespace E_LearningWebApp.Models
{
    public class YoutubeVideos
    {
        [Key]
        public int VideoId { get; set; }
        public string VideoUrl { get; set; }
    }
}
