using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class EstimateAcquiredVehicle
    {
        public long Id { get; set; }
        public long BrandId { get; set; }
        public string VehicleType { get; set; }
        public string Status { get; set; }
        public string Model { get; set; }
        public int Displacement { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Km { get; set; }
        public string Plate { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public DateTime? BolloExpiry { get; set; }
        public DateTime? RevisionExpiry { get; set; }
        public int? Warranty { get; set; }
        public int? Owners { get; set; }
        public string Frame { get; set; }
        public string Note { get; set; }
        public long EstimateId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Estimate Estimate { get; set; }
    }
}
