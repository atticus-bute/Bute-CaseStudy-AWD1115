using Microsoft.EntityFrameworkCore;
using SportsPro.Models.Configuration;
using SportsPro.Models.DomainModels;
namespace SportsPro.Models.DataLayer
{
    public class SportsProContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Technician> Technicians { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Incident> Incidents { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public SportsProContext(DbContextOptions<SportsProContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new TechnicianConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new IncidentConfig());
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.Entity<Customer>().HasMany(c => c.RegisteredProducts).WithMany(p => p.RegisteredCustomers).UsingEntity(cp => cp.HasData(
                new { RegisteredProductsProductId = 1, RegisteredCustomersCustomerId = 1 },
                new { RegisteredProductsProductId = 2, RegisteredCustomersCustomerId = 1 },
                new { RegisteredProductsProductId = 3, RegisteredCustomersCustomerId = 1 }
            ));
        }
    }
}
