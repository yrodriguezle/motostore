using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class StockVehicle
    {
        public ulong VehicleId { get; set; }
        public ulong StockId { get; set; }
        public ulong UserId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Stock Stock { get; set; } = null!;
        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
