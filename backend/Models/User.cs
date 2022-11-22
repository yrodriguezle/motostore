using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? RoleId { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
