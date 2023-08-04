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
        public virtual DbSet<PasswordReset> PasswordResets { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<Marchi> Marchi { get; set; }
        public virtual DbSet<Modelli> Modelli { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("Default");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci").HasCharSet("latin1");
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
            modelBuilder.Entity<User>(entity =>
            {
                entity.Ignore("Keys");
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
                entity.Property(e => e.PasswordHash)
                    .HasColumnType("text")
                    .HasColumnName("passwordHash");
                entity.Property(e => e.PasswordSalt)
                    .HasColumnType("text")
                    .HasColumnName("passwordSalt");
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

            modelBuilder.Entity<Marchi>((entity) => {

            });
            modelBuilder.Entity<Modelli>((entity) => {

            });
        }
    }
}
