using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Complete
    {
        public ulong Id { get; set; }
        public string Code { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
