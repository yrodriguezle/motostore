using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Country
    {
        public uint Id { get; set; }
        public string Country1 { get; set; } = null!;
        public string? Flag { get; set; }
        public string? Capital { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
