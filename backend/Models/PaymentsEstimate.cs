using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class PaymentsEstimate
    {
        public long Id { get; set; }
        public long PaymentId { get; set; }
        public long EstimateId { get; set; }
        public double? Amount { get; set; }
        public string Notes { get; set; }

        public virtual Estimate Estimate { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
