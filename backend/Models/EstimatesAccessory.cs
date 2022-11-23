using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class EstimatesAccessory
    {
        public ulong EstimateId { get; set; }
        public ulong AccessoryId { get; set; }

        public virtual Accessory Accessory { get; set; } = null!;
        public virtual Estimate Estimate { get; set; } = null!;
    }
}
