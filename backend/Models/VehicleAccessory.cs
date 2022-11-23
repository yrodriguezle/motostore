using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class VehicleAccessory
    {
        public ulong VehicleId { get; set; }
        public ulong AccessoryId { get; set; }

        public virtual Accessory Accessory { get; set; } = null!;
        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
