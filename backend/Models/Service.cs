using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Service
    {
        public Service()
        {
            ContractsServices = new HashSet<ContractsService>();
            EstimatesServices = new HashSet<EstimatesService>();
        }

        public ulong Id { get; set; }
        public string Code { get; set; } = null!;
        public string? DefaultDescription { get; set; }
        public double? DefaultPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ContractsService> ContractsServices { get; set; }
        public virtual ICollection<EstimatesService> EstimatesServices { get; set; }
    }
}
