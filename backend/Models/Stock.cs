using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Stock
    {
        public Stock()
        {
            StockVehicles = new HashSet<StockVehicle>();
        }

        public ulong Id { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<StockVehicle> StockVehicles { get; set; }
    }
}
