using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class ContractDocument
    {
        public long Id { get; set; }
        public long ContractId { get; set; }
        public long UserId { get; set; }
        public string DisplayName { get; set; }
        public string FileName { get; set; }

        public virtual Contract Contract { get; set; }
    }
}
