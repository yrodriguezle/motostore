using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class StockVehicle
    {
        public long VehicleId { get; set; }
        public long StockId { get; set; }
        public long UserId { get; set; }

        public virtual Stock Stock { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
