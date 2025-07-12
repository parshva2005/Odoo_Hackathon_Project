using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Odoo_Hackathon_Project.Models
{
    public partial class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string Role { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

        [JsonIgnore]
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        [JsonIgnore]
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

        [JsonIgnore]
        public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }

}

