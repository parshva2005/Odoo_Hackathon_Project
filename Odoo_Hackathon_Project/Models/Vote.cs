using System;
using System.Collections.Generic;

namespace Odoo_Hackathon_Project.Models
{
    public partial class Vote
    {
        public int Id { get; set; }

        public int AnswerId { get; set; }

        public int UserId { get; set; }

        public string VoteType { get; set; } = null!;

        public virtual Answer Answer { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}


