using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Accessory
    {
        public Accessory()
        {
            StepsAccessories = new HashSet<StepsAccessory>();
        }

        public ulong Id { get; set; }
        public string? Code { get; set; }
        public string Description { get; set; } = null!;
        public double? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<StepsAccessory> StepsAccessories { get; set; }
    }
}
