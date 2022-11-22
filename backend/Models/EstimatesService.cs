using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class EstimatesService
    {
        public long EstimateId { get; set; }
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Estimate Estimate { get; set; }
        public virtual Service Service { get; set; }
    }
}
