using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class ContractDocument
    {
        public ulong Id { get; set; }
        public ulong ContractId { get; set; }
        public ulong UserId { get; set; }
        public string DisplayName { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Contract Contract { get; set; } = null!;
    }
}
