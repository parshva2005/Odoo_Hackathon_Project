using System.Text.Json.Serialization;

namespace Odoo_Hackathon_Project.Models
{
    public partial class Question
    {
        /*public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Content { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<Answer> AnswersNavigation { get; set; } = new List<Answer>();

        public virtual User User { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

        [JsonIgnore]
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();*/

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Simulated fields (not from API)
        public int Likes { get; set; }
        public int Views { get; set; }
        public int AnswerCount { get; set; }
        public bool IsRead { get; set; }
    }

    namespace Odoo_Hackathon_API.Models
    {
        public class DashboardQuestionDTO
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string? Content { get; set; }
            public DateTime CreatedAt { get; set; }

            public int AnswerCount { get; set; }
            public int VoteCount { get; set; }
            public int Views { get; set; } // Optional mock
        }
    }

}
