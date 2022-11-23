using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Area
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Cap { get; set; }
        public string Region { get; set; } = null!;
        public string Province { get; set; } = null!;
        public int Prefix { get; set; }
        public string TaxCode { get; set; } = null!;
        public double? Surface { get; set; }
        public int? ResidentsNum { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CountryId { get; set; }
    }
}
