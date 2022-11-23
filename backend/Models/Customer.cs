using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Estimates = new HashSet<Estimate>();
            Phones = new HashSet<Phone>();
        }

        public ulong Id { get; set; }
        public int? PrevId { get; set; }
        public string Gender { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Email { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? BirthProvince { get; set; }
        public string? FiscalCode { get; set; }
        public string? MobilePhone { get; set; }
        public string? Note { get; set; }
        public string? IdentityCard { get; set; }
        public string? IdentityCardReleaseFrom { get; set; }
        public DateOnly? IdentityCardReleaseDate { get; set; }
        public DateOnly? IdentityCardExpiryDate { get; set; }
        public string? BirthCountry { get; set; }
        public string? Cap { get; set; }
        public string? Card { get; set; }
        public string? CardRef { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LicenseReleaseFrom { get; set; }
        public DateOnly? LicenseReleaseDate { get; set; }
        public DateOnly? LicenseExpiryDate { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool? SendSms { get; set; }
        public bool? SendNewsletter { get; set; }
        public bool? SendBirthDate { get; set; }
        public bool? SendReview { get; set; }
        public bool? SendInsurance { get; set; }
        public bool? SendEmail { get; set; }
        public bool? SendFeedback { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Estimate> Estimates { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
    }
}
