using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsPro.Models.DomainModels;

namespace SportsPro.Models.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasData(
                new Customer { CustomerId = 1, FirstName = "Marsh", LastName = "Hill", Address = "1234 Banandy St", City = "Beverly Hills", State = "CA", PostalCode = "90210", CountryId = "usa", Phone = "123465888", Email = "jaogg@mail.com" }
            );
        }
    }
}
