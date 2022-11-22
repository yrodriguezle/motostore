using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Permission
    {
        public Permission()
        {
            PermissionRoles = new HashSet<PermissionRole>();
        }

        public long Id { get; set; }
        public string Key { get; set; }
        public string TableName { get; set; }

        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
