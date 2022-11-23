using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Province
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Province1 { get; set; } = null!;
        public string? Region { get; set; }
    }
}
