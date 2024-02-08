using E_LearningWebApp.Areas.Identity.Data;
using Newtonsoft.Json.Schema;

namespace E_LearningWebApp.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public virtual E_LearningWebAppUser User { get; set; }
        public int SCId { get; set; }
        public int Value { get; set; }
    }
}
