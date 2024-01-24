using System.ComponentModel.DataAnnotations;

namespace MainE_Learning.Models
{
    public class YoutubeVideos
    {
        [Key]
        public int VideoId { get; set; }
        public string VideoUrl { get; set; }
    }
}
