using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class PaymentsContract
    {
        public ulong Id { get; set; }
        public ulong PaymentId { get; set; }
        public ulong ContractId { get; set; }
        public ulong? UserId { get; set; }
        public short? BuiltIn { get; set; }
        public double? Amount { get; set; }
        public string? Notes { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Contract Contract { get; set; } = null!;
        public virtual Payment Payment { get; set; } = null!;
    }
}
