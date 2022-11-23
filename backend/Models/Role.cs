using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Role
    {
        public Role()
        {
            Permissions = new HashSet<Permission>();
            Users = new HashSet<User>();
        }

        public ulong Id { get; set; }
        public string Name { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
