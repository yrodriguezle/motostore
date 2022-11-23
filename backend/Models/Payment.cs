using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Payment
    {
        public Payment()
        {
            PaymentsContracts = new HashSet<PaymentsContract>();
            PaymentsEstimates = new HashSet<PaymentsEstimate>();
        }

        public ulong Id { get; set; }
        public string Payment1 { get; set; } = null!;
        public short? IsDefault { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<PaymentsContract> PaymentsContracts { get; set; }
        public virtual ICollection<PaymentsEstimate> PaymentsEstimates { get; set; }
    }
}
