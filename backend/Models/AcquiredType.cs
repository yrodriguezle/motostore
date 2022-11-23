using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class AcquiredType
    {
        public ulong Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
