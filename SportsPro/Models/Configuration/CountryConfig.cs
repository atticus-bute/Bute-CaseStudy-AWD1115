using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsPro.Models.DomainModels;

namespace SportsPro.Models.Configuration
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasData(
                 new Country { CountryId = "usa", Name = "United States" },
                 new Country { CountryId = "can", Name = "Canada" },
                 new Country { CountryId = "mex", Name = "Mexico" }
            );
        }
    }
}
