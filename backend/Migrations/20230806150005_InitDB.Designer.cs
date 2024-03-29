﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Motostore.DataAccess;

#nullable disable

namespace Motostore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230806150005_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Motostore.Models.Brand", b =>
                {
                    b.Property<string>("Make")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Make");

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("Motostore.Models.Company", b =>
                {
                    b.Property<string>("CompanyCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CompanyCodeOwner")
                        .HasColumnType("varchar(255)");

                    b.HasKey("CompanyCode");

                    b.HasIndex("CompanyCodeOwner");

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("Motostore.Models.Model", b =>
                {
                    b.Property<string>("ModelName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Marchio")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ModelName");

                    b.HasIndex("Marchio");

                    b.ToTable("Models", (string)null);
                });

            modelBuilder.Entity("Motostore.Models.Permission", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("DeleteDenied")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("ExportDenied")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FunctionName")
                        .HasColumnType("longtext");

                    b.Property<bool?>("HideMenuItem")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("InsertDenied")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("PrintDenied")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("ReadDenied")
                        .HasColumnType("tinyint(1)");

                    b.Property<ulong?>("RoleId")
                        .IsRequired()
                        .HasColumnType("bigint unsigned");

                    b.Property<bool?>("SendMailDenied")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("UpdateDenied")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Permissions", (string)null);
                });

            modelBuilder.Entity("Motostore.Models.Role", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Motostore.Models.User", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Avatar")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("EmailVerifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.Property<string>("RememberToken")
                        .HasColumnType("longtext");

                    b.Property<ulong?>("RoleId")
                        .IsRequired()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Settings")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Motostore.Models.Company", b =>
                {
                    b.HasOne("Motostore.Models.Company", null)
                        .WithMany("Companies")
                        .HasForeignKey("CompanyCodeOwner");
                });

            modelBuilder.Entity("Motostore.Models.Model", b =>
                {
                    b.HasOne("Motostore.Models.Brand", "FBrand")
                        .WithMany("Models")
                        .HasForeignKey("Marchio");

                    b.Navigation("FBrand");
                });

            modelBuilder.Entity("Motostore.Models.Permission", b =>
                {
                    b.HasOne("Motostore.Models.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Motostore.Models.User", b =>
                {
                    b.HasOne("Motostore.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Motostore.Models.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Motostore.Models.Company", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("Motostore.Models.Role", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
