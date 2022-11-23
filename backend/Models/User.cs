﻿using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public ulong Id { get; set; }
        public ulong? RoleId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Avatar { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string Password { get; set; } = null!;
        public string? RememberToken { get; set; }
        public string? Settings { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
