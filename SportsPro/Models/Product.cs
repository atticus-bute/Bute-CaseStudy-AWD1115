using System.ComponentModel.DataAnnotations;
namespace SportsPro.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter a product code")]
        public string? ProductCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a product name")]
        public string? Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter an annual product price")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000")]
        [DataType(DataType.Currency)]
        public decimal AnnualPrice { get; set; }
        public DateTime? ReleaseDate { get; set; } = null;
    }
}
