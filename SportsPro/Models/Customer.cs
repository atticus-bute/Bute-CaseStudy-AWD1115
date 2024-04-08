using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using SportsPro.Utility;
namespace SportsPro.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter a first name")]
        [Display(Name = "First Name")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage ="Username may not contain special characters")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name must be between 1 and 50 characters")]
        public string? FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a last name")]
        [Display(Name = "Last Name")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Username may not contain special characters")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name must be between 1 and 50 characters")]
        public string? LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter an address")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Address must be between 1 and 50 characters")]
        public string? Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a city")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "City must be between 1 and 50 characters")]
        public string? City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a state")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "State must be between 1 and 50 characters")]
        public string? State { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a postal code")]
        [Display(Name = "Postal Code")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Postal Code must be between 1 and 21 characters")]
        public string? PostalCode { get; set; } = string.Empty;
        [Display(Name = "Country")]
        public string? CountryId { get; set;} = string.Empty;
        [ValidateNever]
        public Country Country { get; set; } = null!;
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email Address")]
        [NewEmail(ErrorMessage = "Email already in use")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Email Address must be between 1 and 51 characters")]
        public string? Email { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Phone Number must be between 1 and 20 characters")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string? Phone { get; set; } = string.Empty;
        [ValidateNever]
        public List<Product> RegisteredProducts { get; set; } =  new List<Product>();
        public string FullName => $"{FirstName} {LastName}";
    }
}
