using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class AcquiredsContract
    {
        public ulong VehicleId { get; set; }
        public ulong ContractId { get; set; }

        public virtual Contract Contract { get; set; } = null!;
        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
