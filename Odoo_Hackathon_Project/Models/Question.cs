using System.Text.Json.Serialization;

namespace Odoo_Hackathon_Project.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Mocked fields for frontend logic
        public int Likes { get; set; }
        public int Views { get; set; }
        public int AnswerCount { get; set; }
        public bool IsRead { get; set; }
    }

    public class DashboardQuestionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public int AnswerCount { get; set; }
        public int VoteCount { get; set; }
        public int Views { get; set; }
    }
}
