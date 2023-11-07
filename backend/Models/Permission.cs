using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Motostore.Models
{
    public partial class Permission
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }
        public ulong? RoleId { get; set; }
        public string? FunctionName { get; set; }
        public bool? ReadDenied { get; set; }
        public bool? InsertDenied { get; set; }
        public bool? UpdateDenied { get; set; }
        public bool? DeleteDenied { get; set; }
        public bool? ExportDenied { get; set; }
        public bool? SendMailDenied { get; set; }
        public bool? PrintDenied { get; set; }
        public bool? HideMenuItem { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string Key { get; set; } = null!;

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public Permission()
        {
            Role = new Role();
        }
    }
}
