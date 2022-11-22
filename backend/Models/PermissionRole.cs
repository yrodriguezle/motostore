using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class PermissionRole
    {
        public long PermissionId { get; set; }
        public long RoleId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role1 Role { get; set; }
    }
}
