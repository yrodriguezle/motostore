using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Motostore.Models;

namespace Motostore.DataAccess
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Accessory> Accessories { get; set; } = null!;
        public virtual DbSet<AcquiredType> AcquiredTypes { get; set; } = null!;
        public virtual DbSet<AcquiredVehicle> AcquiredVehicles { get; set; } = null!;
        public virtual DbSet<AcquiredsContract> AcquiredsContracts { get; set; } = null!;
        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<CarType> CarTypes { get; set; } = null!;
        public virtual DbSet<CarTypeModel> CarTypeModels { get; set; } = null!;
        public virtual DbSet<Complete> Completes { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<ContractComplete> ContractCompletes { get; set; } = null!;
        public virtual DbSet<ContractDocument> ContractDocuments { get; set; } = null!;
        public virtual DbSet<ContractsAccessory> ContractsAccessories { get; set; } = null!;
        public virtual DbSet<ContractsService> ContractsServices { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DataRow> DataRows { get; set; } = null!;
        public virtual DbSet<DataType> DataTypes { get; set; } = null!;
        public virtual DbSet<ElencoNoleggi> ElencoNoleggis { get; set; } = null!;
        public virtual DbSet<ElencoVeicoliNoleggio> ElencoVeicoliNoleggios { get; set; } = null!;
        public virtual DbSet<Estimate> Estimates { get; set; } = null!;
        public virtual DbSet<EstimateAcquiredVehicle> EstimateAcquiredVehicles { get; set; } = null!;
        public virtual DbSet<EstimatesAccessory> EstimatesAccessories { get; set; } = null!;
        public virtual DbSet<EstimatesService> EstimatesServices { get; set; } = null!;
        public virtual DbSet<Financing> Financings { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<MenuItem> MenuItems { get; set; } = null!;
        public virtual DbSet<Migration> Migrations { get; set; } = null!;
        public virtual DbSet<PasswordReset> PasswordResets { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentsContract> PaymentsContracts { get; set; } = null!;
        public virtual DbSet<PaymentsEstimate> PaymentsEstimates { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Phone> Phones { get; set; } = null!;
        public virtual DbSet<Province> Provinces { get; set; } = null!;
        public virtual DbSet<Rental> Rentals { get; set; } = null!;
        public virtual DbSet<RentalsAccessory> RentalsAccessories { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;
        public virtual DbSet<Step> Steps { get; set; } = null!;
        public virtual DbSet<StepsAccessory> StepsAccessories { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<StockVehicle> StockVehicles { get; set; } = null!;
        public virtual DbSet<Translation> Translations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<VehicleAccessory> VehicleAccessories { get; set; } = null!;
        public virtual DbSet<VehicleProperty> VehicleProperties { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("Default");
                // ServerVersion.Parse("5.7.35-mysql")
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Accessory>(entity =>
            {
                entity.ToTable("accessories");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(191)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Price)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<AcquiredType>(entity =>
            {
                entity.ToTable("acquired_types");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(191)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<AcquiredVehicle>(entity =>
            {
                entity.ToTable("acquired_vehicles");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.VehicleId, "acquired_vehicles_vehicle_id_fk_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AcquiredConditions)
                    .HasMaxLength(191)
                    .HasColumnName("acquired_conditions");

                entity.Property(e => e.AcquiredDate).HasColumnName("acquired_date");

                entity.Property(e => e.AcquiredFrom)
                    .HasMaxLength(191)
                    .HasColumnName("acquired_from")
                    .HasDefaultValueSql("'Zanuso'");

                entity.Property(e => e.AcquiredNotes).HasColumnName("acquired_notes");

                entity.Property(e => e.AcquiredPrice)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("acquired_price");

                entity.Property(e => e.AcquiredSalePrice)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("acquired_sale_price");

                entity.Property(e => e.AcquiredType)
                    .HasMaxLength(191)
                    .HasColumnName("acquired_type");

                entity.Property(e => e.AcquiredTypeId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("acquired_type_id");

                entity.Property(e => e.Archived)
                    .HasColumnName("archived")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CertificatoDiPassggio).HasColumnName("certificato_di_passggio");

                entity.Property(e => e.ChargeDocument)
                    .HasMaxLength(191)
                    .HasColumnName("charge_document");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Notes2).HasColumnName("notes_2");

                entity.Property(e => e.Payed).HasColumnName("payed");

                entity.Property(e => e.PayedDate).HasColumnName("payed_date");

                entity.Property(e => e.ReferenceChargeDocument)
                    .HasMaxLength(191)
                    .HasColumnName("reference_charge_document");

                entity.Property(e => e.ReferenceStockAdvance)
                    .HasMaxLength(191)
                    .HasColumnName("reference_stock_advance");

                entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");

                entity.Property(e => e.StockAdvance).HasColumnName("stock_advance");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("vehicle_id");
            });

            modelBuilder.Entity<AcquiredsContract>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("acquireds_contracts");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ContractId, "acquireds_contracts_contract_id_fk");

                entity.HasIndex(e => e.VehicleId, "acquireds_contracts_vehicle_id_fk");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("vehicle_id");

                entity.HasOne(d => d.Contract)
                    .WithMany()
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("acquireds_contracts_contract_id_fk");

                entity.HasOne(d => d.Vehicle)
                    .WithMany()
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("acquireds_contracts_vehicle_id_fk");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("areas");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Cap)
                    .HasMaxLength(5)
                    .HasColumnName("cap");

                entity.Property(e => e.CountryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("country_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.Prefix)
                    .HasColumnType("int(11)")
                    .HasColumnName("prefix");

                entity.Property(e => e.Province)
                    .HasMaxLength(2)
                    .HasColumnName("province");

                entity.Property(e => e.Region)
                    .HasMaxLength(191)
                    .HasColumnName("region");

                entity.Property(e => e.ResidentsNum)
                    .HasColumnType("int(11)")
                    .HasColumnName("residents_num");

                entity.Property(e => e.Surface)
                    .HasColumnType("double(8,2)")
                    .HasColumnName("surface");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(191)
                    .HasColumnName("tax_code");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.ToTable("car_types");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<CarTypeModel>(entity =>
            {
                entity.ToTable("car_type_models");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Model)
                    .HasMaxLength(191)
                    .HasColumnName("model");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Complete>(entity =>
            {
                entity.ToTable("complete");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(191)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contracts");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccessoriesAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("accessories_agreed");

                entity.Property(e => e.AcquiredAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("acquired_agreed");

                entity.Property(e => e.Archived).HasColumnName("archived");

                entity.Property(e => e.ContractDate).HasColumnName("contract_date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("customer_id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedNote).HasColumnName("deleted_note");

                entity.Property(e => e.GeneralCost)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("general_cost");

                entity.Property(e => e.InternalNotes).HasColumnName("internal_notes");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.OfficeNotes).HasColumnName("office_notes");

                entity.Property(e => e.PriceAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price_agreed");

                entity.Property(e => e.PromotionValue)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("promotion_value");

                entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");

                entity.Property(e => e.TotalPurchase)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("total_purchase");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("vehicle_id");
            });

            modelBuilder.Entity<ContractComplete>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contract_complete");

                entity.Property(e => e.CompleteId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("complete_id");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<ContractDocument>(entity =>
            {
                entity.ToTable("contract_documents");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_bin");

                entity.HasIndex(e => e.ContractId, "contract_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .HasColumnName("file_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractDocuments)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("contract_id");
            });

            modelBuilder.Entity<ContractsAccessory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contracts_accessories");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AccessoryId, "contracts_accessories_accessory_id_fk");

                entity.HasIndex(e => e.ContractId, "contracts_accessories_contract_id_fk");

                entity.Property(e => e.AccessoryId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("accessory_id");

                entity.Property(e => e.Arrived).HasColumnName("arrived");

                entity.Property(e => e.ArrivedDate).HasColumnName("arrived_date");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Accessory)
                    .WithMany()
                    .HasForeignKey(d => d.AccessoryId)
                    .HasConstraintName("contracts_accessories_accessory_id_fk");

                entity.HasOne(d => d.Contract)
                    .WithMany()
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("contracts_accessories_contract_id_fk");
            });

            modelBuilder.Entity<ContractsService>(entity =>
            {
                entity.ToTable("contracts_services");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ContractId, "contracts_services_contract_id_fk");

                entity.HasIndex(e => e.ServiceId, "contracts_services_service_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Price)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("service_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractsServices)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("contracts_services_contract_id_fk");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ContractsServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("contracts_services_service_id_fk");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Capital)
                    .HasMaxLength(255)
                    .HasColumnName("capital");

                entity.Property(e => e.Country1)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Flag)
                    .HasMaxLength(255)
                    .HasColumnName("flag");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(191)
                    .HasColumnName("address");

                entity.Property(e => e.BirthCountry)
                    .HasMaxLength(45)
                    .HasColumnName("birth_country");

                entity.Property(e => e.BirthDate).HasColumnName("birth_date");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(191)
                    .HasColumnName("birth_place");

                entity.Property(e => e.BirthProvince)
                    .HasMaxLength(191)
                    .HasColumnName("birth_province");

                entity.Property(e => e.Cap)
                    .HasMaxLength(5)
                    .HasColumnName("cap");

                entity.Property(e => e.Card)
                    .HasMaxLength(191)
                    .HasColumnName("card");

                entity.Property(e => e.CardRef)
                    .HasMaxLength(191)
                    .HasColumnName("card_ref");

                entity.Property(e => e.City)
                    .HasMaxLength(191)
                    .HasColumnName("city");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(191)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(191)
                    .HasColumnName("first_name");

                entity.Property(e => e.FiscalCode)
                    .HasMaxLength(191)
                    .HasColumnName("fiscal_code");

                entity.Property(e => e.Gender)
                    .HasColumnType("enum('female','male','other')")
                    .HasColumnName("gender");

                entity.Property(e => e.IdentityCard)
                    .HasMaxLength(45)
                    .HasColumnName("identity_card");

                entity.Property(e => e.IdentityCardExpiryDate).HasColumnName("identity_card_expiry_date");

                entity.Property(e => e.IdentityCardReleaseDate).HasColumnName("identity_card_release_date");

                entity.Property(e => e.IdentityCardReleaseFrom)
                    .HasMaxLength(45)
                    .HasColumnName("identity_card_release_from");

                entity.Property(e => e.LastName)
                    .HasMaxLength(191)
                    .HasColumnName("last_name");

                entity.Property(e => e.Latitude)
                    .HasColumnType("double(10,6)")
                    .HasColumnName("latitude");

                entity.Property(e => e.LicenseExpiryDate).HasColumnName("license_expiry_date");

                entity.Property(e => e.LicenseNumber)
                    .HasMaxLength(191)
                    .HasColumnName("license_number");

                entity.Property(e => e.LicenseReleaseDate).HasColumnName("license_release_date");

                entity.Property(e => e.LicenseReleaseFrom)
                    .HasMaxLength(255)
                    .HasColumnName("license_release_from");

                entity.Property(e => e.Location)
                    .HasMaxLength(191)
                    .HasColumnName("location");

                entity.Property(e => e.Longitude)
                    .HasColumnType("double(10,6)")
                    .HasColumnName("longitude");

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(191)
                    .HasColumnName("mobile_phone");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.PrevId)
                    .HasColumnType("int(11)")
                    .HasColumnName("prev_id");

                entity.Property(e => e.Province)
                    .HasMaxLength(191)
                    .HasColumnName("province");

                entity.Property(e => e.SendBirthDate).HasColumnName("send_birth_date");

                entity.Property(e => e.SendEmail).HasColumnName("send_email");

                entity.Property(e => e.SendFeedback).HasColumnName("send_feedback");

                entity.Property(e => e.SendInsurance).HasColumnName("send_insurance");

                entity.Property(e => e.SendNewsletter).HasColumnName("send_newsletter");

                entity.Property(e => e.SendReview).HasColumnName("send_review");

                entity.Property(e => e.SendSms).HasColumnName("send_sms");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasMany(d => d.Phones)
                    .WithMany(p => p.Customers)
                    .UsingEntity<Dictionary<string, object>>(
                        "CustomersPhone",
                        l => l.HasOne<Phone>().WithMany().HasForeignKey("PhoneId").HasConstraintName("customers_phones_phone_id_fk"),
                        r => r.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").HasConstraintName("customers_phones_customer_id_fk"),
                        j =>
                        {
                            j.HasKey("CustomerId", "PhoneId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("customers_phones").HasCharSet("utf8mb4").UseCollation("utf8mb4_unicode_ci");

                            j.HasIndex(new[] { "PhoneId" }, "customers_phones_phone_id_fk");

                            j.IndexerProperty<ulong>("CustomerId").HasColumnType("bigint(20) unsigned").HasColumnName("customer_id");

                            j.IndexerProperty<ulong>("PhoneId").HasColumnType("bigint(20) unsigned").HasColumnName("phone_id");
                        });
            });

            modelBuilder.Entity<DataRow>(entity =>
            {
                entity.ToTable("data_rows");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.DataTypeId, "data_rows_data_type_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Add)
                    .IsRequired()
                    .HasColumnName("add")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Browse)
                    .IsRequired()
                    .HasColumnName("browse")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DataTypeId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("data_type_id");

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnName("delete")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Details)
                    .HasColumnType("text")
                    .HasColumnName("details");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(191)
                    .HasColumnName("display_name");

                entity.Property(e => e.Edit)
                    .IsRequired()
                    .HasColumnName("edit")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Field)
                    .HasMaxLength(191)
                    .HasColumnName("field");

                entity.Property(e => e.Order)
                    .HasColumnType("int(11)")
                    .HasColumnName("order")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Read)
                    .IsRequired()
                    .HasColumnName("read")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Required).HasColumnName("required");

                entity.Property(e => e.Type)
                    .HasMaxLength(191)
                    .HasColumnName("type");

                entity.HasOne(d => d.DataType)
                    .WithMany(p => p.DataRows)
                    .HasForeignKey(d => d.DataTypeId)
                    .HasConstraintName("data_type_id_fk");
            });

            modelBuilder.Entity<DataType>(entity =>
            {
                entity.ToTable("data_types");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Name, "data_types_name_unique")
                    .IsUnique();

                entity.HasIndex(e => e.Slug, "data_types_slug_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Controller)
                    .HasMaxLength(191)
                    .HasColumnName("controller");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(191)
                    .HasColumnName("description");

                entity.Property(e => e.Details)
                    .HasColumnType("text")
                    .HasColumnName("details");

                entity.Property(e => e.DisplayNamePlural)
                    .HasMaxLength(191)
                    .HasColumnName("display_name_plural");

                entity.Property(e => e.DisplayNameSingular)
                    .HasMaxLength(191)
                    .HasColumnName("display_name_singular");

                entity.Property(e => e.GeneratePermissions).HasColumnName("generate_permissions");

                entity.Property(e => e.Icon)
                    .HasMaxLength(191)
                    .HasColumnName("icon");

                entity.Property(e => e.ModelName)
                    .HasMaxLength(191)
                    .HasColumnName("model_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.PolicyName)
                    .HasMaxLength(191)
                    .HasColumnName("policy_name");

                entity.Property(e => e.ServerSide)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("server_side");

                entity.Property(e => e.Slug)
                    .HasMaxLength(191)
                    .HasColumnName("slug");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<ElencoNoleggi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("elenco_noleggi");

                entity.Property(e => e.Accessori).HasColumnName("accessori");

                entity.Property(e => e.CartaNumero)
                    .HasColumnType("text")
                    .HasColumnName("carta_numero");

                entity.Property(e => e.CartaScadenza)
                    .HasColumnType("text")
                    .HasColumnName("carta_scadenza");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataConsegna).HasColumnName("data_consegna");

                entity.Property(e => e.DataRitiro).HasColumnName("data_ritiro");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.IdClienteNoleggio)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_cliente_noleggio");

                entity.Property(e => e.IdVeicoloNoleggio)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_veicolo_noleggio");

                entity.Property(e => e.ImportoCauzione)
                    .HasPrecision(11)
                    .HasColumnName("importo_cauzione");

                entity.Property(e => e.ImportoCauzioneTxt)
                    .HasColumnType("text")
                    .HasColumnName("importo_cauzione_txt");

                entity.Property(e => e.ImportoNoleggio)
                    .HasPrecision(11)
                    .HasColumnName("importo_noleggio");

                entity.Property(e => e.ImportoNoleggioTxt)
                    .HasColumnType("text")
                    .HasColumnName("importo_noleggio_txt");

                entity.Property(e => e.ImportoVersato)
                    .HasPrecision(11)
                    .HasColumnName("importo_versato");

                entity.Property(e => e.ImportoVersatoTxt)
                    .HasColumnType("text")
                    .HasColumnName("importo_versato_txt");

                entity.Property(e => e.KmAttuali)
                    .HasColumnType("int(11)")
                    .HasColumnName("km_attuali");

                entity.Property(e => e.MetodoCauzione)
                    .HasColumnType("text")
                    .HasColumnName("metodo_cauzione");

                entity.Property(e => e.NoteNoleggio).HasColumnName("note_noleggio");

                entity.Property(e => e.OraConsegna)
                    .HasColumnType("text")
                    .HasColumnName("ora_consegna");

                entity.Property(e => e.OraRitiro)
                    .HasColumnType("text")
                    .HasColumnName("ora_ritiro");

                entity.Property(e => e.Percorrenza)
                    .HasColumnType("int(11)")
                    .HasColumnName("percorrenza");
            });

            modelBuilder.Entity<ElencoVeicoliNoleggio>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("elenco_veicoli_noleggio");

                entity.Property(e => e.Assicurazione)
                    .HasColumnType("text")
                    .HasColumnName("assicurazione");

                entity.Property(e => e.AssicurazioneScadenza).HasColumnName("assicurazione_scadenza");

                entity.Property(e => e.Cilindrata)
                    .HasColumnType("int(11)")
                    .HasColumnName("cilindrata");

                entity.Property(e => e.Colore)
                    .HasColumnType("text")
                    .HasColumnName("colore");

                entity.Property(e => e.DataImmatricolazione).HasColumnName("data_immatricolazione");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Intestazione)
                    .HasColumnType("text")
                    .HasColumnName("intestazione");

                entity.Property(e => e.Marca)
                    .HasColumnType("text")
                    .HasColumnName("marca");

                entity.Property(e => e.Modello)
                    .HasColumnType("text")
                    .HasColumnName("modello");

                entity.Property(e => e.StatoVeicolo)
                    .HasColumnType("text")
                    .HasColumnName("stato_veicolo");

                entity.Property(e => e.Targa)
                    .HasColumnType("text")
                    .HasColumnName("targa");

                entity.Property(e => e.Telaio)
                    .HasColumnType("text")
                    .HasColumnName("telaio");
            });

            modelBuilder.Entity<Estimate>(entity =>
            {
                entity.ToTable("estimates");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CustomerId, "customers_estimates_customer_id_fk");

                entity.HasIndex(e => e.VehicleId, "vehicles_estimates_vehicle_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccessoriesAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("accessories_agreed");

                entity.Property(e => e.AcquiredAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("acquired_agreed");

                entity.Property(e => e.Archived).HasColumnName("archived");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("contract_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("customer_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.PriceAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price_agreed");

                entity.Property(e => e.TotalPurchase)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("total_purchase");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasMaxLength(191)
                    .HasColumnName("user_id");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("vehicle_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Estimates)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("customers_estimates_customer_id_fk");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Estimates)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("vehicles_estimates_vehicle_id_fk");
            });

            modelBuilder.Entity<EstimateAcquiredVehicle>(entity =>
            {
                entity.ToTable("estimate_acquired_vehicles");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.EstimateId, "estimate_acquired_vehicles_estimate_id_fk");

                entity.HasIndex(e => e.BrandId, "vehicle_exchange_brand_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.BolloExpiry).HasColumnName("bollo_expiry");

                entity.Property(e => e.BrandId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("brand_id");

                entity.Property(e => e.Color)
                    .HasMaxLength(191)
                    .HasColumnName("color");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Displacement)
                    .HasColumnType("int(11)")
                    .HasColumnName("displacement");

                entity.Property(e => e.EstimateId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("estimate_id");

                entity.Property(e => e.Frame)
                    .HasMaxLength(191)
                    .HasColumnName("frame");

                entity.Property(e => e.Km)
                    .HasColumnType("int(11)")
                    .HasColumnName("km");

                entity.Property(e => e.Model)
                    .HasMaxLength(191)
                    .HasColumnName("model");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Owners)
                    .HasColumnType("int(11)")
                    .HasColumnName("owners");

                entity.Property(e => e.Plate)
                    .HasMaxLength(191)
                    .HasColumnName("plate");

                entity.Property(e => e.Price)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price");

                entity.Property(e => e.RevisionExpiry).HasColumnName("revision_expiry");

                entity.Property(e => e.Status)
                    .HasMaxLength(191)
                    .HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasMaxLength(191)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(191)
                    .HasColumnName("vehicle_type");

                entity.Property(e => e.Warranty)
                    .HasColumnType("int(11)")
                    .HasColumnName("warranty");

                entity.Property(e => e.Year)
                    .HasColumnType("int(11)")
                    .HasColumnName("year");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.EstimateAcquiredVehicles)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("vehicle_exchange_brand_id_fk");

                entity.HasOne(d => d.Estimate)
                    .WithMany(p => p.EstimateAcquiredVehicles)
                    .HasForeignKey(d => d.EstimateId)
                    .HasConstraintName("estimate_acquired_vehicles_estimate_id_fk");
            });

            modelBuilder.Entity<EstimatesAccessory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("estimates_accessories");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AccessoryId, "estimates_accessories_accessory_id_fk");

                entity.HasIndex(e => e.EstimateId, "estimates_accessories_estimate_id_fk");

                entity.Property(e => e.AccessoryId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("accessory_id");

                entity.Property(e => e.EstimateId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("estimate_id");

                entity.HasOne(d => d.Accessory)
                    .WithMany()
                    .HasForeignKey(d => d.AccessoryId)
                    .HasConstraintName("estimates_accessories_accessory_id_fk");

                entity.HasOne(d => d.Estimate)
                    .WithMany()
                    .HasForeignKey(d => d.EstimateId)
                    .HasConstraintName("estimates_accessories_estimate_id_fk");
            });

            modelBuilder.Entity<EstimatesService>(entity =>
            {
                entity.ToTable("estimates_services");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.EstimateId, "estimates_services_estimate_id_fk");

                entity.HasIndex(e => e.ServiceId, "estimates_services_service_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.EstimateId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("estimate_id");

                entity.Property(e => e.Price)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("service_id");

                entity.HasOne(d => d.Estimate)
                    .WithMany(p => p.EstimatesServices)
                    .HasForeignKey(d => d.EstimateId)
                    .HasConstraintName("estimates_services_estimate_id_fk");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.EstimatesServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("estimates_services_service_id_fk");
            });

            modelBuilder.Entity<Financing>(entity =>
            {
                entity.ToTable("financing");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Approvato).HasColumnName("approvato");

                entity.Property(e => e.CasaDiProprieta).HasColumnName("casa_di_proprieta");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.CostoAffitto)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("costo_affitto");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.DaQuanto)
                    .HasMaxLength(255)
                    .HasColumnName("da_quanto");

                entity.Property(e => e.DataApprovazione).HasColumnName("data_approvazione");

                entity.Property(e => e.Dipendente).HasColumnName("dipendente");

                entity.Property(e => e.Figli)
                    .HasColumnType("int(11)")
                    .HasColumnName("figli")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IbanBanca)
                    .HasMaxLength(255)
                    .HasColumnName("iban_banca");

                entity.Property(e => e.InizioAttivitaAssunzione).HasColumnName("inizio_attivita_assunzione");

                entity.Property(e => e.NomeAzienda)
                    .HasMaxLength(255)
                    .HasColumnName("nome_azienda");

                entity.Property(e => e.Occupazione)
                    .HasMaxLength(45)
                    .HasColumnName("occupazione");

                entity.Property(e => e.PartnerDataAssunzione).HasColumnName("partner_data_assunzione");

                entity.Property(e => e.PartnerDataNascita).HasColumnName("partner_data_nascita");

                entity.Property(e => e.PartnerImpiego)
                    .HasMaxLength(255)
                    .HasColumnName("partner_impiego");

                entity.Property(e => e.PartnerLuogoNascita)
                    .HasMaxLength(255)
                    .HasColumnName("partner_luogo_nascita");

                entity.Property(e => e.PartnerNome)
                    .HasMaxLength(255)
                    .HasColumnName("partner_nome");

                entity.Property(e => e.PartnerStipendio)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("partner_stipendio");

                entity.Property(e => e.PrecedenteSe5Anni)
                    .HasMaxLength(255)
                    .HasColumnName("precedente_se_5_anni");

                entity.Property(e => e.Residenza)
                    .HasMaxLength(255)
                    .HasColumnName("residenza");

                entity.Property(e => e.StatoCivile)
                    .HasMaxLength(255)
                    .HasColumnName("stato_civile");

                entity.Property(e => e.TelefonoAzienda)
                    .HasMaxLength(255)
                    .HasColumnName("telefono_azienda");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.Property(e => e.UserIdApprovazione)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id_approvazione");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("images");

                entity.HasIndex(e => e.VehicleId, "image_vehicle_fk_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Filename)
                    .HasMaxLength(255)
                    .HasColumnName("filename");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("vehicle_id");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("image_vehicle_fk");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menus");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Name, "menus_name_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.ToTable("menu_items");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.MenuId, "menu_items_menu_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(191)
                    .HasColumnName("color");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.IconClass)
                    .HasMaxLength(191)
                    .HasColumnName("icon_class");

                entity.Property(e => e.MenuId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("menu_id");

                entity.Property(e => e.Order)
                    .HasColumnType("int(11)")
                    .HasColumnName("order");

                entity.Property(e => e.Parameters)
                    .HasColumnType("text")
                    .HasColumnName("parameters");

                entity.Property(e => e.ParentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("parent_id");

                entity.Property(e => e.Route)
                    .HasMaxLength(191)
                    .HasColumnName("route");

                entity.Property(e => e.Target)
                    .HasMaxLength(191)
                    .HasColumnName("target")
                    .HasDefaultValueSql("'_self'");

                entity.Property(e => e.Title)
                    .HasMaxLength(191)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Url)
                    .HasMaxLength(191)
                    .HasColumnName("url");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("items_menu_id_fk");
            });

            modelBuilder.Entity<Migration>(entity =>
            {
                entity.ToTable("migrations");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Batch)
                    .HasColumnType("int(11)")
                    .HasColumnName("batch");

                entity.Property(e => e.Migration1)
                    .HasMaxLength(191)
                    .HasColumnName("migration");
            });

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_resets");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Email, "password_resets_email_index");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(191)
                    .HasColumnName("email");

                entity.Property(e => e.Token)
                    .HasMaxLength(191)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.IsDefault)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("is_default");

                entity.Property(e => e.Payment1)
                    .HasMaxLength(191)
                    .HasColumnName("payment");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<PaymentsContract>(entity =>
            {
                entity.ToTable("payments_contracts");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ContractId, "payments_contracts_contracts_id_fk");

                entity.HasIndex(e => e.PaymentId, "payments_contracts_payment_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("amount");

                entity.Property(e => e.BuiltIn)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("built_in");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.PaymentId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("payment_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.PaymentsContracts)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("payments_contracts_contracts_id_fk");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.PaymentsContracts)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("payments_contracts_payment_id_fk");
            });

            modelBuilder.Entity<PaymentsEstimate>(entity =>
            {
                entity.ToTable("payments_estimates");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.EstimateId, "payments_estimates_estimates_id_fk");

                entity.HasIndex(e => e.PaymentId, "payments_estimates_payment_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("amount");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.EstimateId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("estimate_id");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.PaymentId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("payment_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Estimate)
                    .WithMany(p => p.PaymentsEstimates)
                    .HasForeignKey(d => d.EstimateId)
                    .HasConstraintName("payments_estimates_estimates_id_fk");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.PaymentsEstimates)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("payments_estimates_payment_id_fk");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permissions");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Key, "permissions_key_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Key)
                    .HasMaxLength(191)
                    .HasColumnName("key");

                entity.Property(e => e.TableName)
                    .HasMaxLength(191)
                    .HasColumnName("table_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Permissions)
                    .UsingEntity<Dictionary<string, object>>(
                        "PermissionRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").HasConstraintName("role_permission_id_fk"),
                        r => r.HasOne<Permission>().WithMany().HasForeignKey("PermissionId").HasConstraintName("permission_role_id_fk"),
                        j =>
                        {
                            j.HasKey("PermissionId", "RoleId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("permission_role").HasCharSet("utf8mb4").UseCollation("utf8mb4_unicode_ci");

                            j.HasIndex(new[] { "PermissionId" }, "permission_role_permission_id_index");

                            j.HasIndex(new[] { "RoleId" }, "permission_role_role_id_index");

                            j.IndexerProperty<ulong>("PermissionId").HasColumnType("bigint(20) unsigned").HasColumnName("permission_id");

                            j.IndexerProperty<ulong>("RoleId").HasColumnType("bigint(20) unsigned").HasColumnName("role_id");
                        });
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phones");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Phone1)
                    .HasMaxLength(191)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("provinces");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(30)
                    .HasColumnName("code");

                entity.Property(e => e.Province1)
                    .HasMaxLength(100)
                    .HasColumnName("province");

                entity.Property(e => e.Region)
                    .HasMaxLength(100)
                    .HasColumnName("region");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("rentals");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CauzioneRestituita)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("cauzione_restituita")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.DataConsegna).HasColumnName("data_consegna");

                entity.Property(e => e.DataRegistrazione).HasColumnName("data_registrazione");

                entity.Property(e => e.DataRitiro).HasColumnName("data_ritiro");

                entity.Property(e => e.ImportoAggiuntivo)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("importo_aggiuntivo");

                entity.Property(e => e.ImportoCauzione)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("importo_cauzione");

                entity.Property(e => e.ImportoNoleggio)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("importo_noleggio");

                entity.Property(e => e.ImportoVersato)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("importo_versato");

                entity.Property(e => e.KmAttuali)
                    .HasColumnType("int(11)")
                    .HasColumnName("km_attuali");

                entity.Property(e => e.KmFinali)
                    .HasColumnType("int(11)")
                    .HasColumnName("km_finali");

                entity.Property(e => e.MetodoCauzione)
                    .HasMaxLength(191)
                    .HasColumnName("metodo_cauzione");

                entity.Property(e => e.NoteNoleggio).HasColumnName("note_noleggio");

                entity.Property(e => e.NumeroCarta)
                    .HasMaxLength(191)
                    .HasColumnName("numero_carta");

                entity.Property(e => e.OraConsegna)
                    .HasMaxLength(45)
                    .HasColumnName("ora_consegna");

                entity.Property(e => e.OraRitiro)
                    .HasMaxLength(45)
                    .HasColumnName("ora_ritiro");

                entity.Property(e => e.Percorrenza)
                    .HasColumnType("int(11)")
                    .HasColumnName("percorrenza");

                entity.Property(e => e.ScadenzaCarta)
                    .HasMaxLength(191)
                    .HasColumnName("scadenza_carta");

                entity.Property(e => e.Status)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.Property(e => e.UserIdArchive)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id_archive");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("vehicle_id");
            });

            modelBuilder.Entity<RentalsAccessory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rentals_accessories");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AccessoryId, "accessory_id_fk");

                entity.HasIndex(e => e.RentalId, "rental_id_fk");

                entity.Property(e => e.AccessoryId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("accessory_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.RentalId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("rental_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Accessory)
                    .WithMany()
                    .HasForeignKey(d => d.AccessoryId)
                    .HasConstraintName("accessory_id_fk");

                entity.HasOne(d => d.Rental)
                    .WithMany()
                    .HasForeignKey(d => d.RentalId)
                    .HasConstraintName("rental_id_fk");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Name, "roles_name_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(191)
                    .HasColumnName("display_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(191)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.DefaultDescription)
                    .HasMaxLength(255)
                    .HasColumnName("default_description");

                entity.Property(e => e.DefaultPrice)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("default_price")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("settings");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Key, "settings_key_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Details)
                    .HasColumnType("text")
                    .HasColumnName("details");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(191)
                    .HasColumnName("display_name");

                entity.Property(e => e.Group)
                    .HasMaxLength(191)
                    .HasColumnName("group");

                entity.Property(e => e.Key)
                    .HasMaxLength(191)
                    .HasColumnName("key");

                entity.Property(e => e.Order)
                    .HasColumnType("int(11)")
                    .HasColumnName("order")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Type)
                    .HasMaxLength(191)
                    .HasColumnName("type");

                entity.Property(e => e.Value)
                    .HasColumnType("text")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.ToTable("steps");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<StepsAccessory>(entity =>
            {
                entity.HasKey(e => new { e.AccessoryId, e.StepId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("steps_accessories");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.StepId, "steps_id_steps_fk");

                entity.Property(e => e.AccessoryId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("accessory_id");

                entity.Property(e => e.StepId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("step_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Accessory)
                    .WithMany(p => p.StepsAccessories)
                    .HasForeignKey(d => d.AccessoryId)
                    .HasConstraintName("accessory_id_accessories_fk");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.StepsAccessories)
                    .HasForeignKey(d => d.StepId)
                    .HasConstraintName("steps_id_steps_fk");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stock");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Status)
                    .HasMaxLength(191)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<StockVehicle>(entity =>
            {
                entity.HasKey(e => new { e.VehicleId, e.StockId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("stock_vehicle");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.StockId, "stock_vehicle_stock_id_fk");

                entity.HasIndex(e => e.VehicleId, "stock_vehicle_vehicle_id_fk");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("vehicle_id");

                entity.Property(e => e.StockId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("stock_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.StockVehicles)
                    .HasForeignKey(d => d.StockId)
                    .HasConstraintName("stock_vehicle_stock_id_fk");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.StockVehicles)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("stock_vehicle_vehicle_id_fk");
            });

            modelBuilder.Entity<Translation>(entity =>
            {
                entity.ToTable("translations");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.TableName, e.ColumnName, e.ForeignKey, e.Locale }, "translations_table_name_column_name_foreign_key_locale_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(64)
                    .HasColumnName("column_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.ForeignKey)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("foreign_key");

                entity.Property(e => e.Locale)
                    .HasMaxLength(2)
                    .HasColumnName("locale");

                entity.Property(e => e.TableName)
                    .HasMaxLength(64)
                    .HasColumnName("table_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasColumnType("text")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Email, "users_email_unique")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId, "users_role_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(191)
                    .HasColumnName("avatar")
                    .HasDefaultValueSql("'users/default.png'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(191)
                    .HasColumnName("email");

                entity.Property(e => e.EmailVerifiedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("email_verified_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(191)
                    .HasColumnName("password");

                entity.Property(e => e.RememberToken)
                    .HasMaxLength(100)
                    .HasColumnName("remember_token");

                entity.Property(e => e.RoleId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("role_id");

                entity.Property(e => e.Settings)
                    .HasColumnType("text")
                    .HasColumnName("settings");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").HasConstraintName("role_user_id_fk"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("user_role_id_fk"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("user_roles").HasCharSet("utf8mb4").UseCollation("utf8mb4_unicode_ci");

                            j.HasIndex(new[] { "RoleId" }, "user_roles_role_id_index");

                            j.HasIndex(new[] { "UserId" }, "user_roles_user_id_index");

                            j.IndexerProperty<ulong>("UserId").HasColumnType("bigint(20) unsigned").HasColumnName("user_id");

                            j.IndexerProperty<ulong>("RoleId").HasColumnType("bigint(20) unsigned").HasColumnName("role_id");
                        });
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicles");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.BrandId, "vehicles_brand_id_fk");

                entity.HasIndex(e => e.TypeId, "vehicles_type_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AcquiredDate).HasColumnName("acquired_date");

                entity.Property(e => e.BolloExpiry).HasColumnName("bollo_expiry");

                entity.Property(e => e.Brand)
                    .HasMaxLength(191)
                    .HasColumnName("brand");

                entity.Property(e => e.BrandId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("brand_id");

                entity.Property(e => e.Color)
                    .HasMaxLength(191)
                    .HasColumnName("color");

                entity.Property(e => e.Costs)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("costs");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");

                entity.Property(e => e.Displacement)
                    .HasColumnType("int(11)")
                    .HasColumnName("displacement");

                entity.Property(e => e.Frame)
                    .HasMaxLength(191)
                    .HasColumnName("frame");

                entity.Property(e => e.From)
                    .HasMaxLength(191)
                    .HasColumnName("from");

                entity.Property(e => e.InCustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("in_customer_id");

                entity.Property(e => e.InternalNote).HasColumnName("internal_note");

                entity.Property(e => e.Invoice)
                    .HasMaxLength(255)
                    .HasColumnName("invoice");

                entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");

                entity.Property(e => e.InvoiceExpiryDate).HasColumnName("invoice_expiry_date");

                entity.Property(e => e.InvoicePaymentDate).HasColumnName("invoice_payment_date");

                entity.Property(e => e.InvoicePaymentType)
                    .HasMaxLength(255)
                    .HasColumnName("invoice_payment_type");

                entity.Property(e => e.InvoiceRelease).HasColumnName("invoice_release");

                entity.Property(e => e.Km)
                    .HasColumnType("int(11)")
                    .HasColumnName("km");

                entity.Property(e => e.ListPrice)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("list_price");

                entity.Property(e => e.Model)
                    .HasMaxLength(191)
                    .HasColumnName("model");

                entity.Property(e => e.OtherExpenses)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("other_expenses");

                entity.Property(e => e.OutCustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("out_customer_id");

                entity.Property(e => e.PackagePrice)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("package_price");

                entity.Property(e => e.ParentId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_id");

                entity.Property(e => e.PermutaCustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("permuta_customer_id");

                entity.Property(e => e.PermutaId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("permuta_id");

                entity.Property(e => e.Plate)
                    .HasMaxLength(191)
                    .HasColumnName("plate");

                entity.Property(e => e.PlateDate).HasColumnName("plate_date");

                entity.Property(e => e.PrevId)
                    .HasColumnType("int(11)")
                    .HasColumnName("prev_id");

                entity.Property(e => e.Promotion)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("promotion");

                entity.Property(e => e.Rented).HasColumnName("rented");

                entity.Property(e => e.RevisionExpiry).HasColumnName("revision_expiry");

                entity.Property(e => e.SaleDate).HasColumnName("sale_date");

                entity.Property(e => e.SalePrice)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("sale_price");

                entity.Property(e => e.Status)
                    .HasColumnType("enum('new','used','rented')")
                    .HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasMaxLength(191)
                    .HasColumnName("type");

                entity.Property(e => e.TypeId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("type_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.Property(e => e.VehicleConditions).HasColumnName("vehicle_conditions");

                entity.Property(e => e.VehicleNote).HasColumnName("vehicle_note");

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(191)
                    .HasColumnName("vehicle_type");

                entity.Property(e => e.Version)
                    .HasMaxLength(191)
                    .HasColumnName("version");

                entity.Property(e => e.Web).HasColumnName("web");

                entity.Property(e => e.WebDescription).HasColumnName("web_description");

                entity.Property(e => e.Year)
                    .HasColumnType("int(11)")
                    .HasColumnName("year");

                entity.HasOne(d => d.BrandNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("vehicles_brand_id_fk");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("vehicles_type_id_fk");
            });

            modelBuilder.Entity<VehicleAccessory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vehicle_accessory");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AccessoryId, "vehicle_accessory_accessory_id_fk");

                entity.HasIndex(e => e.VehicleId, "vehicle_accessory_vehicle_id_fk");

                entity.Property(e => e.AccessoryId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("accessory_id");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("vehicle_id");

                entity.HasOne(d => d.Accessory)
                    .WithMany()
                    .HasForeignKey(d => d.AccessoryId)
                    .HasConstraintName("vehicle_accessory_accessory_id_fk");

                entity.HasOne(d => d.Vehicle)
                    .WithMany()
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("vehicle_accessory_vehicle_id_fk");
            });

            modelBuilder.Entity<VehicleProperty>(entity =>
            {
                entity.ToTable("vehicle_properties");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AbsSystem).HasColumnName("abs_system");

                entity.Property(e => e.BackTire)
                    .HasColumnType("int(11)")
                    .HasColumnName("back_tire")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BolloCopy).HasColumnName("bollo_copy");

                entity.Property(e => e.CirculationBooklet).HasColumnName("circulation_booklet");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at");

                entity.Property(e => e.Equipment).HasColumnName("equipment");

                entity.Property(e => e.FrontTire)
                    .HasColumnType("int(11)")
                    .HasColumnName("front_tire")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.KeyCode).HasColumnName("key_code");

                entity.Property(e => e.Keys).HasColumnName("keys");

                entity.Property(e => e.MainKey).HasColumnName("main_key");

                entity.Property(e => e.MaintenanceBooklet).HasColumnName("maintenance_booklet");

                entity.Property(e => e.MasterKey).HasColumnName("master_key");

                entity.Property(e => e.Owners)
                    .HasColumnType("int(11)")
                    .HasColumnName("owners")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.OwnershipCertificate).HasColumnName("ownership_certificate");

                entity.Property(e => e.Procura).HasColumnName("procura");

                entity.Property(e => e.SecondKey).HasColumnName("second_key");

                entity.Property(e => e.TagliandoBlooklet).HasColumnName("tagliando_blooklet");

                entity.Property(e => e.ToolKit).HasColumnName("tool_kit");

                entity.Property(e => e.TrackOnly).HasColumnName("track_only");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("updated_at");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("vehicle_id");

                entity.Property(e => e.Warranty)
                    .HasMaxLength(45)
                    .HasColumnName("warranty");

                entity.Property(e => e.WarrantyBlooklet).HasColumnName("warranty_blooklet");

                entity.Property(e => e.Weakened).HasColumnName("weakened");
            });
        }
    }
}
