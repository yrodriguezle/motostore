using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class ContractComplete
    {
        public long ContractId { get; set; }
        public long CompleteId { get; set; }
        public bool? Status { get; set; }
        public long UserId { get; set; }
    }
}
