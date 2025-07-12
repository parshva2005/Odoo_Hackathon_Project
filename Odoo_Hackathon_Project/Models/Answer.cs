using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Odoo_Hackathon_Project.Models
{
    public partial class Answer
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public int QuestionId { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Question Question { get; set; } = null!;

        public virtual User User { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();

        [JsonIgnore]
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}


