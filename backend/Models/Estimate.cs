using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Estimate
    {
        public Estimate()
        {
            EstimateAcquiredVehicles = new HashSet<EstimateAcquiredVehicle>();
            EstimatesServices = new HashSet<EstimatesService>();
            PaymentsEstimates = new HashSet<PaymentsEstimate>();
        }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long VehicleId { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }
        public double PriceAgreed { get; set; }
        public double AccessoriesAgreed { get; set; }
        public double AcquiredAgreed { get; set; }
        public double TotalPurchase { get; set; }
        public bool? Archived { get; set; }
        public long? ContractId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<EstimateAcquiredVehicle> EstimateAcquiredVehicles { get; set; }
        public virtual ICollection<EstimatesService> EstimatesServices { get; set; }
        public virtual ICollection<PaymentsEstimate> PaymentsEstimates { get; set; }
    }
}
