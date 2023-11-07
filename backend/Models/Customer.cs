using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Motostore.Models
{
    public class Customer
    {
        [Key]
        public string CodeCustomer { get; set; }
        public string CompanyCode { get; set; }
        public byte? CustomerType { get; set; }
        public string? BusinessName { get; set; }
        public string? BusinessDescription { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? VatNumber { get; set; }
        public string? TaxIdCode { get; set; }
        public string? AbiBank { get; set; }
        public string? CabBank { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("CompanyCode")]
        public virtual Company Company { get; set; }

        public Customer()
        {
            CodeCustomer = Guid.NewGuid().ToString();
            CompanyCode = string.Empty;
            Company = new Company();
        }
    }
}
