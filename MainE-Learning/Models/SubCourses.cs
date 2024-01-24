using System.ComponentModel.DataAnnotations;

namespace MainE_Learning.Models
{
    public class SubCourses
    {
        [Key]
        public int SubCourseId { get; set; }
        public string SubCourseName { get; set;}
        public string SubCourseDescription { get; set;}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}

    }
}
