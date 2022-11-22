using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Step
    {
        public Step()
        {
            StepsAccessories = new HashSet<StepsAccessory>();
        }

        public long Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<StepsAccessory> StepsAccessories { get; set; }
    }
}
