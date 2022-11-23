using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class StepsAccessory
    {
        public ulong AccessoryId { get; set; }
        public ulong StepId { get; set; }
        public long UserId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Accessory Accessory { get; set; } = null!;
        public virtual Step Step { get; set; } = null!;
    }
}
