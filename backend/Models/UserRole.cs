using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class UserRole
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        public virtual Role1 Role { get; set; }
        public virtual User User { get; set; }
    }
}
