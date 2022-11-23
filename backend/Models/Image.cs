using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Image
    {
        public ulong Id { get; set; }
        public string? Filename { get; set; }
        public ulong? VehicleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Vehicle? Vehicle { get; set; }
    }
}
