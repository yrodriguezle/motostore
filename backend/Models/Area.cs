using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Area
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Cap { get; set; }
        public string Region { get; set; }
        public string Province { get; set; }
        public int Prefix { get; set; }
        public string TaxCode { get; set; }
        public double? Surface { get; set; }
        public int? ResidentsNum { get; set; }
        public int? CountryId { get; set; }
    }
}
