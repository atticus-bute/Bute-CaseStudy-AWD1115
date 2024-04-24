using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models.ViewModels
{
    public class RegisterAccountViewModel
    {
        [Required(ErrorMessage = "Please enter a username")]
        [StringLength(255)]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [StringLength(255)]
        [Compare("ConfirmPassword", ErrorMessage = "Passwords do not match")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Please confirm password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
