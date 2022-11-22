using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class CarType
    {
        public CarType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public long Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
