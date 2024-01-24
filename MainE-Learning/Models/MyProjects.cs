using System.ComponentModel.DataAnnotations;

namespace MainE_Learning.Models
{
    public class MyProjects
    {
        [Key]
        public int MyProjectId { get; set; }
        public string ProjectStatus { get; set; }

    }
}
