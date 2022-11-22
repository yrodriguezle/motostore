using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Role1
    {
        public Role1()
        {
            PermissionRoles = new HashSet<PermissionRole>();
            UserRoles = new HashSet<UserRole>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
