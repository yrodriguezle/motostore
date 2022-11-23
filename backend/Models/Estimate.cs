using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Estimate
    {
        public Estimate()
        {
            EstimateAcquiredVehicles = new HashSet<EstimateAcquiredVehicle>();
            EstimatesServices = new HashSet<EstimatesService>();
            PaymentsEstimates = new HashSet<PaymentsEstimate>();
        }

        public ulong Id { get; set; }
        public ulong CustomerId { get; set; }
        public ulong VehicleId { get; set; }
        public DateOnly Date { get; set; }
        public string UserId { get; set; } = null!;
        public string? Note { get; set; }
        public double PriceAgreed { get; set; }
        public double AccessoriesAgreed { get; set; }
        public double AcquiredAgreed { get; set; }
        public double TotalPurchase { get; set; }
        public bool? Archived { get; set; }
        public long? ContractId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Vehicle Vehicle { get; set; } = null!;
        public virtual ICollection<EstimateAcquiredVehicle> EstimateAcquiredVehicles { get; set; }
        public virtual ICollection<EstimatesService> EstimatesServices { get; set; }
        public virtual ICollection<PaymentsEstimate> PaymentsEstimates { get; set; }
    }
}
