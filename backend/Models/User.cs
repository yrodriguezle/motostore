using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Motostore.Helpers;

namespace Motostore.Models
{
    public class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }
        public ulong? RoleId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Avatar { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string Password { get; set; } = null!;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? RememberToken { get; set; }
        public string? Settings { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string Keys { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public User()
        {
            Keys = Guid.NewGuid().ToString();
            Role = new Role();
        }
    }
}
