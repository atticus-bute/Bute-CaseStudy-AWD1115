using Microsoft.EntityFrameworkCore;
namespace SportsPro.Models
{
    public class SportsProContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Technician> Technicians { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Incident> Incidents { get; set; } = null!;
        public SportsProContext(DbContextOptions<SportsProContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductCode = "TRNY10", Name = "Tournament Master 1.0", AnnualPrice = 4.99M, ReleaseDate = new DateTime(2016, 3, 1) },
                new Product { ProductId = 2, ProductCode = "LEAG10", Name = "League Scheduler 1.0", AnnualPrice = 4.99M, ReleaseDate = new DateTime(2016, 3, 1) },
                new Product { ProductId = 3, ProductCode = "TEAM10", Name = "Team Manager 1.0", AnnualPrice = 4.99M, ReleaseDate = new DateTime(2016, 3, 1) },
                new Product { ProductId = 4, ProductCode = "TRNY20", Name = "Tournament Master 2.0", AnnualPrice = 5.99M, ReleaseDate = new DateTime(2018, 12, 1) },
                new Product { ProductId = 5, ProductCode = "LEAG20", Name = "League Scheduler 2.0", AnnualPrice = 5.99M, ReleaseDate = new DateTime(2018, 12, 1) },
                new Product { ProductId = 6, ProductCode = "TEAM20", Name = "Team Manager 2.0", AnnualPrice = 5.99M, ReleaseDate = new DateTime(2018, 12, 1) }
            );
            modelBuilder.Entity<Technician>().HasData(
                new Technician { TechnicianId = 1, FirstName = "Hector", LastName = "Lector", Email = "asdf@asdf.com", Phone = "123465888" }
            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "Candy", LastName = "Kong", Address = "1234 Main St", City = "Beverly Hills", State = "CA", PostalCode = "90210", Country = "USA", Phone = "123465888", Email = "jaogg@mail.com" }
            );
        }
    }
}
