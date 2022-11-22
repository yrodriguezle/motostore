using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Image
    {
        public long Id { get; set; }
        public string Filename { get; set; }
        public long? VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
