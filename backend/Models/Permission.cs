using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Permission
    {
        public Permission()
        {
            Roles = new HashSet<Role>();
        }

        public ulong Id { get; set; }
        public string Key { get; set; } = null!;
        public string? TableName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
