using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using MOTOSTORE.Models;

namespace MOTOSTORE.DataAccess
{
    public partial class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<AcquiredType> AcquiredTypes { get; set; }
        public virtual DbSet<AcquiredVehicle> AcquiredVehicles { get; set; }
        public virtual DbSet<AcquiredsContract> AcquiredsContracts { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<CarTypeModel> CarTypeModels { get; set; }
        public virtual DbSet<Complete> Completes { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractComplete> ContractCompletes { get; set; }
        public virtual DbSet<ContractDocument> ContractDocuments { get; set; }
        public virtual DbSet<ContractsAccessory> ContractsAccessories { get; set; }
        public virtual DbSet<ContractsService> ContractsServices { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomersPhone> CustomersPhones { get; set; }
        public virtual DbSet<DataRow> DataRows { get; set; }
        public virtual DbSet<DataType> DataTypes { get; set; }
        public virtual DbSet<ElencoNoleggi> ElencoNoleggis { get; set; }
        public virtual DbSet<ElencoVeicoliNoleggio> ElencoVeicoliNoleggios { get; set; }
        public virtual DbSet<Estimate> Estimates { get; set; }
        public virtual DbSet<EstimateAcquiredVehicle> EstimateAcquiredVehicles { get; set; }
        public virtual DbSet<EstimatesAccessory> EstimatesAccessories { get; set; }
        public virtual DbSet<EstimatesService> EstimatesServices { get; set; }
        public virtual DbSet<Financing> Financings { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Migration> Migrations { get; set; }
        public virtual DbSet<PasswordReset> PasswordResets { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentsContract> PaymentsContracts { get; set; }
        public virtual DbSet<PaymentsEstimate> PaymentsEstimates { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionRole> PermissionRoles { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<RentalsAccessory> RentalsAccessories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Role1> Roles1 { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<StepsAccessory> StepsAccessories { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockVehicle> StockVehicles { get; set; }
        public virtual DbSet<Translation> Translations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleAccessory> VehicleAccessories { get; set; }
        public virtual DbSet<VehicleProperty> VehicleProperties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(Configuration.GetConnectionString("Motostore"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessory>(entity =>
            {
                entity.ToTable("accessories");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(191)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("description");

                entity.Property(e => e.Price)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<AcquiredType>(entity =>
            {
                entity.ToTable("acquired_types");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AcquiredVehicle>(entity =>
            {
                entity.ToTable("acquired_vehicles");

                entity.HasIndex(e => e.VehicleId, "acquired_vehicles_vehicle_id_fk_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AcquiredConditions)
                    .HasMaxLength(191)
                    .HasColumnName("acquired_conditions");

                entity.Property(e => e.AcquiredDate)
                    .HasColumnType("date")
                    .HasColumnName("acquired_date");

                entity.Property(e => e.AcquiredFrom)
                    .HasMaxLength(191)
                    .HasColumnName("acquired_from")
                    .HasDefaultValueSql("'Zanuso'");

                entity.Property(e => e.AcquiredNotes)
                    .HasColumnType("longtext")
                    .HasColumnName("acquired_notes");

                entity.Property(e => e.AcquiredPrice)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("acquired_price");

                entity.Property(e => e.AcquiredSalePrice)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("acquired_sale_price");

                entity.Property(e => e.AcquiredType)
                    .HasMaxLength(191)
                    .HasColumnName("acquired_type");

                entity.Property(e => e.AcquiredTypeId).HasColumnName("acquired_type_id");

                entity.Property(e => e.Archived)
                    .HasColumnName("archived")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CertificatoDiPassggio).HasColumnName("certificato_di_passggio");

                entity.Property(e => e.ChargeDocument)
                    .HasMaxLength(191)
                    .HasColumnName("charge_document");

                entity.Property(e => e.Notes2)
                    .HasColumnType("longtext")
                    .HasColumnName("notes_2");

                entity.Property(e => e.Payed).HasColumnName("payed");

                entity.Property(e => e.PayedDate)
                    .HasColumnType("date")
                    .HasColumnName("payed_date");

                entity.Property(e => e.ReferenceChargeDocument)
                    .HasMaxLength(191)
                    .HasColumnName("reference_charge_document");

                entity.Property(e => e.ReferenceStockAdvance)
                    .HasMaxLength(191)
                    .HasColumnName("reference_stock_advance");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("date")
                    .HasColumnName("registration_date");

                entity.Property(e => e.StockAdvance).HasColumnName("stock_advance");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("vehicle_id");
            });

            modelBuilder.Entity<AcquiredsContract>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("acquireds_contracts");

                entity.HasIndex(e => e.ContractId, "acquireds_contracts_contract_id_fk");

                entity.HasIndex(e => e.VehicleId, "acquireds_contracts_vehicle_id_fk");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint unsigned")
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

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Cap)
                    .HasMaxLength(5)
                    .HasColumnName("cap");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.Prefix).HasColumnName("prefix");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("province");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("region");

                entity.Property(e => e.ResidentsNum).HasColumnName("residents_num");

                entity.Property(e => e.Surface)
                    .HasColumnType("double(8,2)")
                    .HasColumnName("surface");

                entity.Property(e => e.TaxCode)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("tax_code");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.ToTable("car_types");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<CarTypeModel>(entity =>
            {
                entity.ToTable("car_type_models");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("model");
            });

            modelBuilder.Entity<Complete>(entity =>
            {
                entity.ToTable("complete");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("code");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contracts");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccessoriesAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("accessories_agreed");

                entity.Property(e => e.AcquiredAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("acquired_agreed");

                entity.Property(e => e.Archived).HasColumnName("archived");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("date")
                    .HasColumnName("contract_date");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("customer_id");

                entity.Property(e => e.DeletedNote)
                    .HasColumnType("longtext")
                    .HasColumnName("deleted_note");

                entity.Property(e => e.GeneralCost)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("general_cost");

                entity.Property(e => e.InternalNotes)
                    .HasColumnType("longtext")
                    .HasColumnName("internal_notes");

                entity.Property(e => e.Notes)
                    .HasColumnType("longtext")
                    .HasColumnName("notes");

                entity.Property(e => e.OfficeNotes)
                    .HasColumnType("longtext")
                    .HasColumnName("office_notes");

                entity.Property(e => e.PriceAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price_agreed");

                entity.Property(e => e.PromotionValue)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("promotion_value");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("date")
                    .HasColumnName("registration_date");

                entity.Property(e => e.TotalPurchase)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("total_purchase");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            });

            modelBuilder.Entity<ContractComplete>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contract_complete");

                entity.Property(e => e.CompleteId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("complete_id");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<ContractDocument>(entity =>
            {
                entity.ToTable("contract_documents");

                entity.HasIndex(e => e.ContractId, "contract_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("file_name");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint unsigned")
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

                entity.HasIndex(e => e.AccessoryId, "contracts_accessories_accessory_id_fk");

                entity.HasIndex(e => e.ContractId, "contracts_accessories_contract_id_fk");

                entity.Property(e => e.AccessoryId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("accessory_id");

                entity.Property(e => e.Arrived).HasColumnName("arrived");

                entity.Property(e => e.ArrivedDate)
                    .HasColumnType("date")
                    .HasColumnName("arrived_date");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

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

                entity.HasIndex(e => e.ContractId, "contracts_services_contract_id_fk");

                entity.HasIndex(e => e.ServiceId, "contracts_services_service_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Price)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("service_id");

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

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Capital)
                    .HasMaxLength(255)
                    .HasColumnName("capital");

                entity.Property(e => e.Country1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.Flag)
                    .HasMaxLength(255)
                    .HasColumnName("flag");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(191)
                    .HasColumnName("address");

                entity.Property(e => e.BirthCountry)
                    .HasMaxLength(45)
                    .HasColumnName("birth_country");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

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
                    .IsRequired()
                    .HasColumnType("enum('female','male','other')")
                    .HasColumnName("gender");

                entity.Property(e => e.IdentityCard)
                    .HasMaxLength(45)
                    .HasColumnName("identity_card");

                entity.Property(e => e.IdentityCardExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("identity_card_expiry_date");

                entity.Property(e => e.IdentityCardReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("identity_card_release_date");

                entity.Property(e => e.IdentityCardReleaseFrom)
                    .HasMaxLength(45)
                    .HasColumnName("identity_card_release_from");

                entity.Property(e => e.LastName)
                    .HasMaxLength(191)
                    .HasColumnName("last_name");

                entity.Property(e => e.Latitude)
                    .HasColumnType("double(10,6)")
                    .HasColumnName("latitude");

                entity.Property(e => e.LicenseExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("license_expiry_date");

                entity.Property(e => e.LicenseNumber)
                    .HasMaxLength(191)
                    .HasColumnName("license_number");

                entity.Property(e => e.LicenseReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("license_release_date");

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

                entity.Property(e => e.Note)
                    .HasColumnType("longtext")
                    .HasColumnName("note");

                entity.Property(e => e.PrevId).HasColumnName("prev_id");

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
            });

            modelBuilder.Entity<CustomersPhone>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.PhoneId })
                    .HasName("PRIMARY");

                entity.ToTable("customers_phones");

                entity.HasIndex(e => e.PhoneId, "customers_phones_phone_id_fk");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("customer_id");

                entity.Property(e => e.PhoneId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("phone_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomersPhones)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("customers_phones_customer_id_fk");

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.CustomersPhones)
                    .HasForeignKey(d => d.PhoneId)
                    .HasConstraintName("customers_phones_phone_id_fk");
            });

            modelBuilder.Entity<DataRow>(entity =>
            {
                entity.ToTable("data_rows");

                entity.HasIndex(e => e.DataTypeId, "data_rows_data_type_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
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
                    .HasColumnType("int unsigned")
                    .HasColumnName("data_type_id");

                entity.Property(e => e.Delete)
                    .IsRequired()
                    .HasColumnName("delete")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Details).HasColumnName("details");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("display_name");

                entity.Property(e => e.Edit)
                    .IsRequired()
                    .HasColumnName("edit")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("field");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Read)
                    .IsRequired()
                    .HasColumnName("read")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Required).HasColumnName("required");

                entity.Property(e => e.Type)
                    .IsRequired()
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

                entity.HasIndex(e => e.Name, "data_types_name_unique")
                    .IsUnique();

                entity.HasIndex(e => e.Slug, "data_types_slug_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Controller)
                    .HasMaxLength(191)
                    .HasColumnName("controller");

                entity.Property(e => e.Description)
                    .HasMaxLength(191)
                    .HasColumnName("description");

                entity.Property(e => e.Details).HasColumnName("details");

                entity.Property(e => e.DisplayNamePlural)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("display_name_plural");

                entity.Property(e => e.DisplayNameSingular)
                    .IsRequired()
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
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.PolicyName)
                    .HasMaxLength(191)
                    .HasColumnName("policy_name");

                entity.Property(e => e.ServerSide)
                    .HasColumnType("tinyint")
                    .HasColumnName("server_side");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("slug");
            });

            modelBuilder.Entity<ElencoNoleggi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("elenco_noleggi");

                entity.Property(e => e.Accessori)
                    .HasColumnType("longtext")
                    .HasColumnName("accessori");

                entity.Property(e => e.CartaNumero).HasColumnName("carta_numero");

                entity.Property(e => e.CartaScadenza).HasColumnName("carta_scadenza");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data");

                entity.Property(e => e.DataConsegna)
                    .HasColumnType("date")
                    .HasColumnName("data_consegna");

                entity.Property(e => e.DataRitiro)
                    .HasColumnType("date")
                    .HasColumnName("data_ritiro");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.IdClienteNoleggio).HasColumnName("id_cliente_noleggio");

                entity.Property(e => e.IdVeicoloNoleggio).HasColumnName("id_veicolo_noleggio");

                entity.Property(e => e.ImportoCauzione)
                    .HasColumnType("decimal(11,0)")
                    .HasColumnName("importo_cauzione");

                entity.Property(e => e.ImportoCauzioneTxt).HasColumnName("importo_cauzione_txt");

                entity.Property(e => e.ImportoNoleggio)
                    .HasColumnType("decimal(11,0)")
                    .HasColumnName("importo_noleggio");

                entity.Property(e => e.ImportoNoleggioTxt).HasColumnName("importo_noleggio_txt");

                entity.Property(e => e.ImportoVersato)
                    .HasColumnType("decimal(11,0)")
                    .HasColumnName("importo_versato");

                entity.Property(e => e.ImportoVersatoTxt).HasColumnName("importo_versato_txt");

                entity.Property(e => e.KmAttuali).HasColumnName("km_attuali");

                entity.Property(e => e.MetodoCauzione).HasColumnName("metodo_cauzione");

                entity.Property(e => e.NoteNoleggio)
                    .HasColumnType("longtext")
                    .HasColumnName("note_noleggio");

                entity.Property(e => e.OraConsegna).HasColumnName("ora_consegna");

                entity.Property(e => e.OraRitiro).HasColumnName("ora_ritiro");

                entity.Property(e => e.Percorrenza).HasColumnName("percorrenza");
            });

            modelBuilder.Entity<ElencoVeicoliNoleggio>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("elenco_veicoli_noleggio");

                entity.Property(e => e.Assicurazione).HasColumnName("assicurazione");

                entity.Property(e => e.AssicurazioneScadenza)
                    .HasColumnType("date")
                    .HasColumnName("assicurazione_scadenza");

                entity.Property(e => e.Cilindrata).HasColumnName("cilindrata");

                entity.Property(e => e.Colore).HasColumnName("colore");

                entity.Property(e => e.DataImmatricolazione)
                    .HasColumnType("date")
                    .HasColumnName("data_immatricolazione");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Intestazione).HasColumnName("intestazione");

                entity.Property(e => e.Marca).HasColumnName("marca");

                entity.Property(e => e.Modello).HasColumnName("modello");

                entity.Property(e => e.StatoVeicolo).HasColumnName("stato_veicolo");

                entity.Property(e => e.Targa).HasColumnName("targa");

                entity.Property(e => e.Telaio).HasColumnName("telaio");
            });

            modelBuilder.Entity<Estimate>(entity =>
            {
                entity.ToTable("estimates");

                entity.HasIndex(e => e.CustomerId, "customers_estimates_customer_id_fk");

                entity.HasIndex(e => e.VehicleId, "vehicles_estimates_vehicle_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccessoriesAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("accessories_agreed");

                entity.Property(e => e.AcquiredAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("acquired_agreed");

                entity.Property(e => e.Archived).HasColumnName("archived");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("customer_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Note)
                    .HasColumnType("longtext")
                    .HasColumnName("note");

                entity.Property(e => e.PriceAgreed)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price_agreed");

                entity.Property(e => e.TotalPurchase)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("total_purchase");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("user_id");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint unsigned")
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

                entity.HasIndex(e => e.EstimateId, "estimate_acquired_vehicles_estimate_id_fk");

                entity.HasIndex(e => e.BrandId, "vehicle_exchange_brand_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.BolloExpiry)
                    .HasColumnType("date")
                    .HasColumnName("bollo_expiry");

                entity.Property(e => e.BrandId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("brand_id");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("color");

                entity.Property(e => e.Displacement).HasColumnName("displacement");

                entity.Property(e => e.EstimateId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("estimate_id");

                entity.Property(e => e.Frame)
                    .HasMaxLength(191)
                    .HasColumnName("frame");

                entity.Property(e => e.Km).HasColumnName("km");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("model");

                entity.Property(e => e.Note)
                    .HasColumnType("longtext")
                    .HasColumnName("note");

                entity.Property(e => e.Owners).HasColumnName("owners");

                entity.Property(e => e.Plate)
                    .HasMaxLength(191)
                    .HasColumnName("plate");

                entity.Property(e => e.Price)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price");

                entity.Property(e => e.RevisionExpiry)
                    .HasColumnType("date")
                    .HasColumnName("revision_expiry");

                entity.Property(e => e.Status)
                    .HasMaxLength(191)
                    .HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasMaxLength(191)
                    .HasColumnName("type");

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(191)
                    .HasColumnName("vehicle_type");

                entity.Property(e => e.Warranty).HasColumnName("warranty");

                entity.Property(e => e.Year).HasColumnName("year");

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

                entity.HasIndex(e => e.AccessoryId, "estimates_accessories_accessory_id_fk");

                entity.HasIndex(e => e.EstimateId, "estimates_accessories_estimate_id_fk");

                entity.Property(e => e.AccessoryId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("accessory_id");

                entity.Property(e => e.EstimateId)
                    .HasColumnType("bigint unsigned")
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

                entity.HasIndex(e => e.EstimateId, "estimates_services_estimate_id_fk");

                entity.HasIndex(e => e.ServiceId, "estimates_services_service_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.EstimateId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("estimate_id");

                entity.Property(e => e.Price)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("price");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("bigint unsigned")
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

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Approvato).HasColumnName("approvato");

                entity.Property(e => e.CasaDiProprieta).HasColumnName("casa_di_proprieta");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.CostoAffitto)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("costo_affitto");

                entity.Property(e => e.DaQuanto)
                    .HasMaxLength(255)
                    .HasColumnName("da_quanto");

                entity.Property(e => e.DataApprovazione)
                    .HasColumnType("date")
                    .HasColumnName("data_approvazione");

                entity.Property(e => e.Dipendente).HasColumnName("dipendente");

                entity.Property(e => e.Figli)
                    .HasColumnName("figli")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IbanBanca)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("iban_banca");

                entity.Property(e => e.InizioAttivitaAssunzione)
                    .HasColumnType("date")
                    .HasColumnName("inizio_attivita_assunzione");

                entity.Property(e => e.NomeAzienda)
                    .HasMaxLength(255)
                    .HasColumnName("nome_azienda");

                entity.Property(e => e.Occupazione)
                    .HasMaxLength(45)
                    .HasColumnName("occupazione");

                entity.Property(e => e.PartnerDataAssunzione)
                    .HasColumnType("date")
                    .HasColumnName("partner_data_assunzione");

                entity.Property(e => e.PartnerDataNascita)
                    .HasColumnType("date")
                    .HasColumnName("partner_data_nascita");

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

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("user_id");

                entity.Property(e => e.UserIdApprovazione).HasColumnName("user_id_approvazione");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("images");

                entity.HasIndex(e => e.VehicleId, "image_vehicle_fk_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Filename)
                    .HasMaxLength(255)
                    .HasColumnName("filename");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint unsigned")
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

                entity.HasIndex(e => e.Name, "menus_name_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.ToTable("menu_items");

                entity.HasIndex(e => e.MenuId, "menu_items_menu_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(191)
                    .HasColumnName("color");

                entity.Property(e => e.IconClass)
                    .HasMaxLength(191)
                    .HasColumnName("icon_class");

                entity.Property(e => e.MenuId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("menu_id");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Parameters).HasColumnName("parameters");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Route)
                    .HasMaxLength(191)
                    .HasColumnName("route");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("target")
                    .HasDefaultValueSql("'_self'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("title");

                entity.Property(e => e.Url)
                    .IsRequired()
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

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Batch).HasColumnName("batch");

                entity.Property(e => e.Migration1)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("migration");
            });

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_resets");

                entity.HasIndex(e => e.Email, "password_resets_email_index");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("email");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.Payment1)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("payment");
            });

            modelBuilder.Entity<PaymentsContract>(entity =>
            {
                entity.ToTable("payments_contracts");

                entity.HasIndex(e => e.ContractId, "payments_contracts_contracts_id_fk");

                entity.HasIndex(e => e.PaymentId, "payments_contracts_payment_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("amount");

                entity.Property(e => e.BuiltIn).HasColumnName("built_in");

                entity.Property(e => e.ContractId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("contract_id");

                entity.Property(e => e.Notes)
                    .HasColumnType("longtext")
                    .HasColumnName("notes");

                entity.Property(e => e.PaymentId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("payment_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint unsigned")
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

                entity.HasIndex(e => e.EstimateId, "payments_estimates_estimates_id_fk");

                entity.HasIndex(e => e.PaymentId, "payments_estimates_payment_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("amount");

                entity.Property(e => e.EstimateId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("estimate_id");

                entity.Property(e => e.Notes)
                    .HasColumnType("longtext")
                    .HasColumnName("notes");

                entity.Property(e => e.PaymentId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("payment_id");

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

                entity.HasIndex(e => e.Key, "permissions_key_index");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("key");

                entity.Property(e => e.TableName)
                    .HasMaxLength(191)
                    .HasColumnName("table_name");
            });

            modelBuilder.Entity<PermissionRole>(entity =>
            {
                entity.HasKey(e => new { e.PermissionId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("permission_role");

                entity.HasIndex(e => e.PermissionId, "permission_role_permission_id_index");

                entity.HasIndex(e => e.RoleId, "permission_role_role_id_index");

                entity.Property(e => e.PermissionId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("permission_id");

                entity.Property(e => e.RoleId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("role_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionRoles)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("permission_role_id_fk");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("role_permission_id_fk");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phones");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Phone1)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("provinces");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("code");

                entity.Property(e => e.Province1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("province");

                entity.Property(e => e.Region)
                    .HasMaxLength(100)
                    .HasColumnName("region");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("rentals");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CauzioneRestituita)
                    .HasColumnType("tinyint")
                    .HasColumnName("cauzione_restituita")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DataConsegna)
                    .HasColumnType("date")
                    .HasColumnName("data_consegna");

                entity.Property(e => e.DataRegistrazione)
                    .HasColumnType("date")
                    .HasColumnName("data_registrazione");

                entity.Property(e => e.DataRitiro)
                    .HasColumnType("date")
                    .HasColumnName("data_ritiro");

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

                entity.Property(e => e.KmAttuali).HasColumnName("km_attuali");

                entity.Property(e => e.KmFinali).HasColumnName("km_finali");

                entity.Property(e => e.MetodoCauzione)
                    .HasMaxLength(191)
                    .HasColumnName("metodo_cauzione");

                entity.Property(e => e.NoteNoleggio)
                    .HasColumnType("longtext")
                    .HasColumnName("note_noleggio");

                entity.Property(e => e.NumeroCarta)
                    .HasMaxLength(191)
                    .HasColumnName("numero_carta");

                entity.Property(e => e.OraConsegna)
                    .HasMaxLength(45)
                    .HasColumnName("ora_consegna");

                entity.Property(e => e.OraRitiro)
                    .HasMaxLength(45)
                    .HasColumnName("ora_ritiro");

                entity.Property(e => e.Percorrenza).HasColumnName("percorrenza");

                entity.Property(e => e.ScadenzaCarta)
                    .HasMaxLength(191)
                    .HasColumnName("scadenza_carta");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("user_id");

                entity.Property(e => e.UserIdArchive)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("user_id_archive");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            });

            modelBuilder.Entity<RentalsAccessory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rentals_accessories");

                entity.HasIndex(e => e.AccessoryId, "accessory_id_fk");

                entity.HasIndex(e => e.RentalId, "rental_id_fk");

                entity.Property(e => e.AccessoryId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("accessory_id");

                entity.Property(e => e.RentalId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("rental_id");

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
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Role1>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.Name, "roles_name_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("display_name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("code");

                entity.Property(e => e.DefaultDescription)
                    .HasMaxLength(255)
                    .HasColumnName("default_description");

                entity.Property(e => e.DefaultPrice)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("default_price")
                    .HasDefaultValueSql("'0.00'");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("settings");

                entity.HasIndex(e => e.Key, "settings_key_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Details).HasColumnName("details");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("display_name");

                entity.Property(e => e.Group)
                    .HasMaxLength(191)
                    .HasColumnName("group");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("key");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("type");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.ToTable("steps");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<StepsAccessory>(entity =>
            {
                entity.HasKey(e => new { e.AccessoryId, e.StepId })
                    .HasName("PRIMARY");

                entity.ToTable("steps_accessories");

                entity.HasIndex(e => e.StepId, "steps_id_steps_fk");

                entity.Property(e => e.AccessoryId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("accessory_id");

                entity.Property(e => e.StepId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("step_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

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

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Status)
                    .HasMaxLength(191)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<StockVehicle>(entity =>
            {
                entity.HasKey(e => new { e.VehicleId, e.StockId })
                    .HasName("PRIMARY");

                entity.ToTable("stock_vehicle");

                entity.HasIndex(e => e.StockId, "stock_vehicle_stock_id_fk");

                entity.HasIndex(e => e.VehicleId, "stock_vehicle_vehicle_id_fk");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("vehicle_id");

                entity.Property(e => e.StockId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("stock_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint unsigned")
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

                entity.HasIndex(e => new { e.TableName, e.ColumnName, e.ForeignKey, e.Locale }, "translations_table_name_column_name_foreign_key_locale_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("column_name");

                entity.Property(e => e.ForeignKey)
                    .HasColumnType("int unsigned")
                    .HasColumnName("foreign_key");

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("locale");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("table_name");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("roleId");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("user_roles");

                entity.HasIndex(e => e.RoleId, "user_roles_role_id_index");

                entity.HasIndex(e => e.UserId, "user_roles_user_id_index");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("user_id");

                entity.Property(e => e.RoleId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("role_user_id_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_role_id_fk");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicles");

                entity.HasIndex(e => e.BrandId, "vehicles_brand_id_fk");

                entity.HasIndex(e => e.TypeId, "vehicles_type_id_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AcquiredDate)
                    .HasColumnType("date")
                    .HasColumnName("acquired_date");

                entity.Property(e => e.BolloExpiry)
                    .HasColumnType("date")
                    .HasColumnName("bollo_expiry");

                entity.Property(e => e.Brand)
                    .HasMaxLength(191)
                    .HasColumnName("brand");

                entity.Property(e => e.BrandId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("brand_id");

                entity.Property(e => e.Color)
                    .HasMaxLength(191)
                    .HasColumnName("color");

                entity.Property(e => e.Costs)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("costs");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("date")
                    .HasColumnName("delivery_date");

                entity.Property(e => e.Displacement).HasColumnName("displacement");

                entity.Property(e => e.Frame)
                    .HasMaxLength(191)
                    .HasColumnName("frame");

                entity.Property(e => e.From)
                    .HasMaxLength(191)
                    .HasColumnName("from");

                entity.Property(e => e.InCustomerId).HasColumnName("in_customer_id");

                entity.Property(e => e.InternalNote)
                    .HasColumnType("longtext")
                    .HasColumnName("internal_note");

                entity.Property(e => e.Invoice)
                    .HasMaxLength(255)
                    .HasColumnName("invoice");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("date")
                    .HasColumnName("invoice_date");

                entity.Property(e => e.InvoiceExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("invoice_expiry_date");

                entity.Property(e => e.InvoicePaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("invoice_payment_date");

                entity.Property(e => e.InvoicePaymentType)
                    .HasMaxLength(255)
                    .HasColumnName("invoice_payment_type");

                entity.Property(e => e.InvoiceRelease).HasColumnName("invoice_release");

                entity.Property(e => e.Km).HasColumnName("km");

                entity.Property(e => e.ListPrice)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("list_price");

                entity.Property(e => e.Model)
                    .HasMaxLength(191)
                    .HasColumnName("model");

                entity.Property(e => e.OtherExpenses)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("other_expenses");

                entity.Property(e => e.OutCustomerId).HasColumnName("out_customer_id");

                entity.Property(e => e.PackagePrice)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("package_price");

                entity.Property(e => e.ParentId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("parent_id");

                entity.Property(e => e.PermutaCustomerId).HasColumnName("permuta_customer_id");

                entity.Property(e => e.PermutaId).HasColumnName("permuta_id");

                entity.Property(e => e.Plate)
                    .HasMaxLength(191)
                    .HasColumnName("plate");

                entity.Property(e => e.PlateDate)
                    .HasColumnType("date")
                    .HasColumnName("plate_date");

                entity.Property(e => e.PrevId).HasColumnName("prev_id");

                entity.Property(e => e.Promotion)
                    .HasColumnType("double(16,2)")
                    .HasColumnName("promotion");

                entity.Property(e => e.Rented).HasColumnName("rented");

                entity.Property(e => e.RevisionExpiry)
                    .HasColumnType("date")
                    .HasColumnName("revision_expiry");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("date")
                    .HasColumnName("sale_date");

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
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("type_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VehicleConditions)
                    .HasColumnType("longtext")
                    .HasColumnName("vehicle_conditions");

                entity.Property(e => e.VehicleNote)
                    .HasColumnType("longtext")
                    .HasColumnName("vehicle_note");

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(191)
                    .HasColumnName("vehicle_type");

                entity.Property(e => e.Version)
                    .HasMaxLength(191)
                    .HasColumnName("version");

                entity.Property(e => e.Web).HasColumnName("web");

                entity.Property(e => e.WebDescription)
                    .HasColumnType("longtext")
                    .HasColumnName("web_description");

                entity.Property(e => e.Year).HasColumnName("year");

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

                entity.HasIndex(e => e.AccessoryId, "vehicle_accessory_accessory_id_fk");

                entity.HasIndex(e => e.VehicleId, "vehicle_accessory_vehicle_id_fk");

                entity.Property(e => e.AccessoryId)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("accessory_id");

                entity.Property(e => e.VehicleId)
                    .HasColumnType("bigint unsigned")
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

                entity.Property(e => e.Id)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AbsSystem).HasColumnName("abs_system");

                entity.Property(e => e.BackTire)
                    .HasColumnName("back_tire")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BolloCopy).HasColumnName("bollo_copy");

                entity.Property(e => e.CirculationBooklet).HasColumnName("circulation_booklet");

                entity.Property(e => e.Equipment).HasColumnName("equipment");

                entity.Property(e => e.FrontTire)
                    .HasColumnName("front_tire")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.KeyCode).HasColumnName("key_code");

                entity.Property(e => e.Keys).HasColumnName("keys");

                entity.Property(e => e.MainKey).HasColumnName("main_key");

                entity.Property(e => e.MaintenanceBooklet).HasColumnName("maintenance_booklet");

                entity.Property(e => e.MasterKey).HasColumnName("master_key");

                entity.Property(e => e.Owners)
                    .HasColumnName("owners")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.OwnershipCertificate).HasColumnName("ownership_certificate");

                entity.Property(e => e.Procura).HasColumnName("procura");

                entity.Property(e => e.SecondKey).HasColumnName("second_key");

                entity.Property(e => e.TagliandoBlooklet).HasColumnName("tagliando_blooklet");

                entity.Property(e => e.ToolKit).HasColumnName("tool_kit");

                entity.Property(e => e.TrackOnly).HasColumnName("track_only");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.Property(e => e.Warranty)
                    .HasMaxLength(45)
                    .HasColumnName("warranty");

                entity.Property(e => e.WarrantyBlooklet).HasColumnName("warranty_blooklet");

                entity.Property(e => e.Weakened).HasColumnName("weakened");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
