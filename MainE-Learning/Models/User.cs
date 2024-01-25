using System.ComponentModel.DataAnnotations;

namespace MainE_Learning.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        [Required]
        [Display(Name = "Upload Cover")]
        public string imagePath { get; set; }

    }
}
