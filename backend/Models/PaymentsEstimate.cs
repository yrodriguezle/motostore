using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class PaymentsEstimate
    {
        public ulong Id { get; set; }
        public ulong PaymentId { get; set; }
        public ulong EstimateId { get; set; }
        public double? Amount { get; set; }
        public string? Notes { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Estimate Estimate { get; set; } = null!;
        public virtual Payment Payment { get; set; } = null!;
    }
}
