using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Stock
    {
        public Stock()
        {
            StockVehicles = new HashSet<StockVehicle>();
        }

        public long Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<StockVehicle> StockVehicles { get; set; }
    }
}
