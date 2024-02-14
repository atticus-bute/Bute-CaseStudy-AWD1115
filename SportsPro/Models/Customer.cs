using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace SportsPro.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter a first name")]
        public string? FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a last name")]
        public string? LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter an address")]
        public string? Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a city")]
        public string? City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a state")]
        public string? State { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a postal code")]
        public string? PostalCode { get; set; } = string.Empty;
        public string? CountryId { get; set;} = string.Empty;
        [ValidateNever]
        public Country Country { get; set; } = null!;
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
    }
}
