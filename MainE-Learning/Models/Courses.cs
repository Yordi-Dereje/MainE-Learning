using System.ComponentModel.DataAnnotations;

namespace MainE_Learning.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string CourseCode { get; set; }

        [Required]
        public string CourseDescription { get; set; }

        [Required]
        public int CoursePrice { get; set; }

        [Required]
        public DateTime CourseDuration { get; set; }

    }
}
