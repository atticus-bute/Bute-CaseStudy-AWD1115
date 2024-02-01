using System.ComponentModel.DataAnnotations;
namespace SportsPro.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }
        [Required(ErrorMessage = "Please enter a first name")]
        public string? FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a last name")]
        public string? LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter an email address")]
        public string? Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a phone number")]
        public string? Phone { get; set; } = string.Empty;
        public string FullName() { return $"{FirstName} {LastName}";} 
    }
}
