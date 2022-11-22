﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Estimates = new HashSet<Estimate>();
            Images = new HashSet<Image>();
            StockVehicles = new HashSet<StockVehicle>();
        }

        public long Id { get; set; }
        public long? ParentId { get; set; }
        public int? PrevId { get; set; }
        public int? UserId { get; set; }
        public string From { get; set; }
        public DateTime? AcquiredDate { get; set; }
        public DateTime? SaleDate { get; set; }
        public DateTime? PlateDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Status { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public int? Displacement { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public int? Km { get; set; }
        public string Plate { get; set; }
        public string Frame { get; set; }
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
        public string VehicleNote { get; set; }
        public string InternalNote { get; set; }
        public string WebDescription { get; set; }
        public bool? Web { get; set; }
        public DateTime? RevisionExpiry { get; set; }
        public DateTime? BolloExpiry { get; set; }
        public string VehicleConditions { get; set; }
        public string Brand { get; set; }
        public string VehicleType { get; set; }
        public string Invoice { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoicePaymentType { get; set; }
        public DateTime? InvoicePaymentDate { get; set; }
        public DateTime? InvoiceExpiryDate { get; set; }
        public bool? InvoiceRelease { get; set; }
        public bool? Rented { get; set; }
        public long? BrandId { get; set; }
        public long? TypeId { get; set; }

        public virtual Brand BrandNavigation { get; set; }
        public virtual CarType TypeNavigation { get; set; }
        public virtual ICollection<Estimate> Estimates { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<StockVehicle> StockVehicles { get; set; }
    }
}
