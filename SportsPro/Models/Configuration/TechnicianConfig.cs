using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsPro.Models.DomainModels;

namespace SportsPro.Models.Configuration
{
    public class TechnicianConfig : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> entity)
        {
            entity.HasData(
                new Technician { TechnicianId = 1, FirstName = "Dan", LastName = "Dresden", Email = "sidedraft@strbrd.com", Phone = "123465888" }
            );
        }
    }
}
