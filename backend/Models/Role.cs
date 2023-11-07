namespace Motostore.Models
{
    public partial class Role
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Permissions = new List<Permission>();
            Users = new List<User>();
        }
    }
}
