using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Estimates = new HashSet<Estimate>();
            Images = new HashSet<Image>();
            StockVehicles = new HashSet<StockVehicle>();
        }

        public ulong Id { get; set; }
        public ulong? ParentId { get; set; }
        public int? PrevId { get; set; }
        public int? UserId { get; set; }
        public string? From { get; set; }
        public DateOnly? AcquiredDate { get; set; }
        public DateOnly? SaleDate { get; set; }
        public DateOnly? PlateDate { get; set; }
        public DateOnly? DeliveryDate { get; set; }
        public string? Status { get; set; }
        public string? Model { get; set; }
        public string? Version { get; set; }
        public int? Displacement { get; set; }
        public int? Year { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }
        public int? Km { get; set; }
        public string? Plate { get; set; }
        public string? Frame { get; set; }
        public double? SalePrice { get; set; }
        public double? PackagePrice { get; set; }
        public double? Costs { get; set; }
        public double? OtherExpenses { get; set; }
        public double? ListPrice { get; set; }
        public double? Promotion { get; set; }
        public int? OutCustomerId { get; set; }
        public int? InCustomerId { get; set; }
        public int? PermutaCustomerId { get; set; }
        public long? PermutaId { get; set; }
        public string? VehicleNote { get; set; }
        public string? InternalNote { get; set; }
        public string? WebDescription { get; set; }
        public bool? Web { get; set; }
        public DateOnly? RevisionExpiry { get; set; }
        public DateOnly? BolloExpiry { get; set; }
        public string? VehicleConditions { get; set; }
        public string? Brand { get; set; }
        public string? VehicleType { get; set; }
        public string? Invoice { get; set; }
        public DateOnly? InvoiceDate { get; set; }
        public string? InvoicePaymentType { get; set; }
        public DateOnly? InvoicePaymentDate { get; set; }
        public DateOnly? InvoiceExpiryDate { get; set; }
        public bool? InvoiceRelease { get; set; }
        public bool? Rented { get; set; }
        public ulong? BrandId { get; set; }
        public ulong? TypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Brand? BrandNavigation { get; set; }
        public virtual CarType? TypeNavigation { get; set; }
        public virtual ICollection<Estimate> Estimates { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<StockVehicle> StockVehicles { get; set; }
    }
}
