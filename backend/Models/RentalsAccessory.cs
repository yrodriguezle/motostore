using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class RentalsAccessory
    {
        public ulong RentalId { get; set; }
        public ulong AccessoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Accessory Accessory { get; set; } = null!;
        public virtual Rental Rental { get; set; } = null!;
    }
}
