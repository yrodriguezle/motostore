using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomersPhones = new HashSet<CustomersPhone>();
            Estimates = new HashSet<Estimate>();
        }

        public long Id { get; set; }
        public int? PrevId { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string BirthProvince { get; set; }
        public string FiscalCode { get; set; }
        public string MobilePhone { get; set; }
        public string Note { get; set; }
        public string IdentityCard { get; set; }
        public string IdentityCardReleaseFrom { get; set; }
        public DateTime? IdentityCardReleaseDate { get; set; }
        public DateTime? IdentityCardExpiryDate { get; set; }
        public string BirthCountry { get; set; }
        public string Cap { get; set; }
        public string Card { get; set; }
        public string CardRef { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseReleaseFrom { get; set; }
        public DateTime? LicenseReleaseDate { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool? SendSms { get; set; }
        public bool? SendNewsletter { get; set; }
        public bool? SendBirthDate { get; set; }
        public bool? SendReview { get; set; }
        public bool? SendInsurance { get; set; }
        public bool? SendEmail { get; set; }
        public bool? SendFeedback { get; set; }

        public virtual ICollection<CustomersPhone> CustomersPhones { get; set; }
        public virtual ICollection<Estimate> Estimates { get; set; }
    }
}
