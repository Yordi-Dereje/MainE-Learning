using System.ComponentModel.DataAnnotations;

namespace MainE_Learning.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        public string AdminName { get; set; }

    }
}
