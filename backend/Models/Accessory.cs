using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Accessory
    {
        public Accessory()
        {
            StepsAccessories = new HashSet<StepsAccessory>();
            Id = 0;
            Code = string.Empty;
            Description = string.Empty;
            Price = 0;
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<StepsAccessory> StepsAccessories { get; set; }
    }
}
