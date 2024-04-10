using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsPro.Models.DomainModels;

namespace SportsPro.Models.Configuration
{
    public class IncidentConfig : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> entity)
        {
            entity.HasData(
                new Incident { IncidentId = 1, Title = "Faulty Product", Description = "The product doesn't work properly.", DateOpened = new DateTime(2021, 1, 1), CustomerId = 1, ProductId = 1, TechnicianId = 1 }
            );
        }
    }
}
