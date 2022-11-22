using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class PaymentsContract
    {
        public long Id { get; set; }
        public long PaymentId { get; set; }
        public long ContractId { get; set; }
        public long? UserId { get; set; }
        public short? BuiltIn { get; set; }
        public double? Amount { get; set; }
        public string Notes { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
