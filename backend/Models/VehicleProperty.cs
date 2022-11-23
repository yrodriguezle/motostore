using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class VehicleProperty
    {
        public ulong Id { get; set; }
        public int VehicleId { get; set; }
        public bool? Procura { get; set; }
        public bool? Keys { get; set; }
        public bool? MaintenanceBooklet { get; set; }
        public bool? CirculationBooklet { get; set; }
        public string? Warranty { get; set; }
        public bool? WarrantyBlooklet { get; set; }
        public int? Owners { get; set; }
        public int? FrontTire { get; set; }
        public int? BackTire { get; set; }
        public bool? Weakened { get; set; }
        public bool? TrackOnly { get; set; }
        public bool? AbsSystem { get; set; }
        public bool? Equipment { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? OwnershipCertificate { get; set; }
        public bool? BolloCopy { get; set; }
        public bool? MainKey { get; set; }
        public bool? SecondKey { get; set; }
        public bool? MasterKey { get; set; }
        public bool? KeyCode { get; set; }
        public bool? ToolKit { get; set; }
        public bool? TagliandoBlooklet { get; set; }
    }
}
