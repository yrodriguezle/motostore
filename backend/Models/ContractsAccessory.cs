using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class ContractsAccessory
    {
        public ulong AccessoryId { get; set; }
        public ulong ContractId { get; set; }
        public bool? Arrived { get; set; }
        public long? UserId { get; set; }
        public DateOnly? ArrivedDate { get; set; }

        public virtual Accessory Accessory { get; set; } = null!;
        public virtual Contract Contract { get; set; } = null!;
    }
}
