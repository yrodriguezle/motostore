using Motostore.Helpers.GraphQLSubscriptions;
using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public class User : IEntity
    {
        public User()
        {
            Keys = Guid.NewGuid().ToString();
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

        public string Keys { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
