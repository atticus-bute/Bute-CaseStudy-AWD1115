using System.ComponentModel.DataAnnotations;
using SportsPro.Models.DataLayer;

namespace SportsPro.Utility
{
    public class NewEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService<IServiceProvider>();
            var dbContext = serviceProvider.GetService<SportsProContext>();
            var email = (string)value;
            var existingEmail = dbContext.Customers.Any(c => c.Email == email);
            if (existingEmail)
            {
                return new ValidationResult("Email already exists");
            }
            return ValidationResult.Success;
        }
    }
}
