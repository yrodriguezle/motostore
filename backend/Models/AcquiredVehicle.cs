using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class AcquiredVehicle
    {
        public ulong Id { get; set; }
        public ulong VehicleId { get; set; }
        public long? UserId { get; set; }
        public DateOnly? AcquiredDate { get; set; }
        public DateOnly? RegistrationDate { get; set; }
        public long? AcquiredTypeId { get; set; }
        public string? AcquiredType { get; set; }
        public string? AcquiredFrom { get; set; }
        public bool? CertificatoDiPassggio { get; set; }
        public string? AcquiredNotes { get; set; }
        public string? Notes2 { get; set; }
        public bool? Payed { get; set; }
        public DateOnly? PayedDate { get; set; }
        public string? ChargeDocument { get; set; }
        public string? ReferenceChargeDocument { get; set; }
        public bool? StockAdvance { get; set; }
        public string? ReferenceStockAdvance { get; set; }
        public string? AcquiredConditions { get; set; }
        public double? AcquiredPrice { get; set; }
        public double? AcquiredSalePrice { get; set; }
        public bool? Archived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
