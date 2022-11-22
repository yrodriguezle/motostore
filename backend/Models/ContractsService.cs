using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class ContractsService
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public long ContractId { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Service Service { get; set; }
    }
}
