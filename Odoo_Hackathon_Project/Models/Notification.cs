﻿using System;
using System.Collections.Generic;

namespace Odoo_Hackathon_Project.Models
{
    public partial class Notification
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string NotificationType { get; set; } = null!;

        public string Message { get; set; } = null!;

        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; } = null!;
    }

}

