using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Brand
    {
        public Brand()
        {
            EstimateAcquiredVehicles = new HashSet<EstimateAcquiredVehicle>();
            Vehicles = new HashSet<Vehicle>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EstimateAcquiredVehicle> EstimateAcquiredVehicles { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
