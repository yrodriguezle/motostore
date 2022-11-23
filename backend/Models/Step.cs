using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Step
    {
        public Step()
        {
            StepsAccessories = new HashSet<StepsAccessory>();
        }

        public ulong Id { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<StepsAccessory> StepsAccessories { get; set; }
    }
}
