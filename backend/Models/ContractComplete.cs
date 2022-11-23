using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class ContractComplete
    {
        public ulong ContractId { get; set; }
        public ulong CompleteId { get; set; }
        public bool? Status { get; set; }
        public ulong UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
