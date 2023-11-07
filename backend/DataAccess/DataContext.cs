using Microsoft.EntityFrameworkCore;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

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
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;

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
            modelBuilder.HasCharSet(CharSet.Utf8Mb4).UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
            });
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permissions")
                    .Ignore("Keys");
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users")
                    .Ignore("Keys");
            });

            modelBuilder.Entity<Brand>((entity) => {
                entity.ToTable("Brands");
            });
            modelBuilder.Entity<Model>((entity) => {
                entity.ToTable("Models");
            });
            modelBuilder.Entity<Company>((entity) => {
                entity.ToTable("Companies");
            });
            modelBuilder.Entity<Customer>((entity) => {
                entity.ToTable("Customers");
            });
        }
    }
}
