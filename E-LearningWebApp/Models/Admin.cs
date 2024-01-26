using System.ComponentModel.DataAnnotations;

namespace E_LearningWebApp.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        public string AdminName { get; set; }

    }
}
