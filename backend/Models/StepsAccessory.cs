using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class StepsAccessory
    {
        public long AccessoryId { get; set; }
        public long StepId { get; set; }
        public long UserId { get; set; }

        public virtual Accessory Accessory { get; set; }
        public virtual Step Step { get; set; }
    }
}
