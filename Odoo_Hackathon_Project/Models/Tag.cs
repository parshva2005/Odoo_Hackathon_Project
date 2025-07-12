using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Odoo_Hackathon_Project.Models
{
    public partial class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}

