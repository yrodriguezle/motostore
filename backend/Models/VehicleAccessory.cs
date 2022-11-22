using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class VehicleAccessory
    {
        public long VehicleId { get; set; }
        public long AccessoryId { get; set; }

        public virtual Accessory Accessory { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
