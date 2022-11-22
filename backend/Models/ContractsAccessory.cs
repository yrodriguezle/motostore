using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class ContractsAccessory
    {
        public long AccessoryId { get; set; }
        public long ContractId { get; set; }
        public bool? Arrived { get; set; }
        public long? UserId { get; set; }
        public DateTime? ArrivedDate { get; set; }

        public virtual Accessory Accessory { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
