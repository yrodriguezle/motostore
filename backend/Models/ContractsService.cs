using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class ContractsService
    {
        public ulong Id { get; set; }
        public ulong ServiceId { get; set; }
        public ulong ContractId { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Contract Contract { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}
