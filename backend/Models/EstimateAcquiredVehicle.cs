using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class EstimateAcquiredVehicle
    {
        public ulong Id { get; set; }
        public ulong BrandId { get; set; }
        public string? VehicleType { get; set; }
        public string? Status { get; set; }
        public string Model { get; set; } = null!;
        public int Displacement { get; set; }
        public int Year { get; set; }
        public string Color { get; set; } = null!;
        public int Km { get; set; }
        public string? Plate { get; set; }
        public double Price { get; set; }
        public string? Type { get; set; }
        public DateOnly? BolloExpiry { get; set; }
        public DateOnly? RevisionExpiry { get; set; }
        public int? Warranty { get; set; }
        public int? Owners { get; set; }
        public string? Frame { get; set; }
        public string? Note { get; set; }
        public ulong EstimateId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual Estimate Estimate { get; set; } = null!;
    }
}
