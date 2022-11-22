using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Contract
    {
        public Contract()
        {
            ContractDocuments = new HashSet<ContractDocument>();
            ContractsServices = new HashSet<ContractsService>();
            PaymentsContracts = new HashSet<PaymentsContract>();
        }

        public long Id { get; set; }
        public long VehicleId { get; set; }
        public long CustomerId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? ContractDate { get; set; }
        public double GeneralCost { get; set; }
        public double PromotionValue { get; set; }
        public double? PriceAgreed { get; set; }
        public double? AccessoriesAgreed { get; set; }
        public double? AcquiredAgreed { get; set; }
        public double? TotalPurchase { get; set; }
        public string Notes { get; set; }
        public string InternalNotes { get; set; }
        public string OfficeNotes { get; set; }
        public bool? Archived { get; set; }
        public int UserId { get; set; }
        public string DeletedNote { get; set; }

        public virtual ICollection<ContractDocument> ContractDocuments { get; set; }
        public virtual ICollection<ContractsService> ContractsServices { get; set; }
        public virtual ICollection<PaymentsContract> PaymentsContracts { get; set; }
    }
}
