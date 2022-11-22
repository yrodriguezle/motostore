using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Service
    {
        public Service()
        {
            ContractsServices = new HashSet<ContractsService>();
            EstimatesServices = new HashSet<EstimatesService>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string DefaultDescription { get; set; }
        public double? DefaultPrice { get; set; }

        public virtual ICollection<ContractsService> ContractsServices { get; set; }
        public virtual ICollection<EstimatesService> EstimatesServices { get; set; }
    }
}
