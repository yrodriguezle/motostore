using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class RentalsAccessory
    {
        public long RentalId { get; set; }
        public long AccessoryId { get; set; }

        public virtual Accessory Accessory { get; set; }
        public virtual Rental Rental { get; set; }
    }
}
