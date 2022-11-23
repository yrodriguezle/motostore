using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Brand
    {
        public Brand()
        {
            EstimateAcquiredVehicles = new HashSet<EstimateAcquiredVehicle>();
            Vehicles = new HashSet<Vehicle>();
        }

        public ulong Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<EstimateAcquiredVehicle> EstimateAcquiredVehicles { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
