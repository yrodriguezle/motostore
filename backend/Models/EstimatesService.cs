using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class EstimatesService
    {
        public ulong EstimateId { get; set; }
        public ulong Id { get; set; }
        public ulong ServiceId { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Estimate Estimate { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}
