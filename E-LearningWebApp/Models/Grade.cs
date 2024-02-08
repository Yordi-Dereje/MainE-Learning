using Newtonsoft.Json.Schema;

namespace E_LearningWebApp.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SCId { get; set; }
        public int Value { get; set; }
    }
}
