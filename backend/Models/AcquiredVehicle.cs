using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class AcquiredVehicle
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public long? UserId { get; set; }
        public DateTime? AcquiredDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public long? AcquiredTypeId { get; set; }
        public string AcquiredType { get; set; }
        public string AcquiredFrom { get; set; }
        public bool? CertificatoDiPassggio { get; set; }
        public string AcquiredNotes { get; set; }
        public string Notes2 { get; set; }
        public bool? Payed { get; set; }
        public DateTime? PayedDate { get; set; }
        public string ChargeDocument { get; set; }
        public string ReferenceChargeDocument { get; set; }
        public bool? StockAdvance { get; set; }
        public string ReferenceStockAdvance { get; set; }
        public string AcquiredConditions { get; set; }
        public double? AcquiredPrice { get; set; }
        public double? AcquiredSalePrice { get; set; }
        public bool? Archived { get; set; }
    }
}
