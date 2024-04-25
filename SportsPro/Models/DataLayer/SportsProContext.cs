using Microsoft.EntityFrameworkCore;
using SportsPro.Models.Configuration;
using SportsPro.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace SportsPro.Models.DataLayer
{
    public class SportsProContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Technician> Technicians { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Incident> Incidents { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public SportsProContext(DbContextOptions<SportsProContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
            string ROLE_ID = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });
            var appUser = new User
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };
            PasswordHasher<User> ph = new PasswordHasher<User>();
            appUser.PasswordHash = ph.HashPassword(appUser, "P@ssw0rd");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(appUser);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
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
