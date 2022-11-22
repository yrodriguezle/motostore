using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Payment
    {
        public Payment()
        {
            PaymentsContracts = new HashSet<PaymentsContract>();
            PaymentsEstimates = new HashSet<PaymentsEstimate>();
        }

        public long Id { get; set; }
        public string Payment1 { get; set; }
        public short? IsDefault { get; set; }

        public virtual ICollection<PaymentsContract> PaymentsContracts { get; set; }
        public virtual ICollection<PaymentsEstimate> PaymentsEstimates { get; set; }
    }
}
