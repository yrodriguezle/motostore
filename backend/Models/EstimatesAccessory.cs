using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class EstimatesAccessory
    {
        public long EstimateId { get; set; }
        public long AccessoryId { get; set; }

        public virtual Accessory Accessory { get; set; }
        public virtual Estimate Estimate { get; set; }
    }
}
