using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class AcquiredsContract
    {
        public long VehicleId { get; set; }
        public long ContractId { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
