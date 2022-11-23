using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class CarTypeModel
    {
        public ulong Id { get; set; }
        public string Model { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
