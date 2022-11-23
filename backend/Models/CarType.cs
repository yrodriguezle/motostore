using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class CarType
    {
        public CarType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public ulong Id { get; set; }
        public string? Type { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
