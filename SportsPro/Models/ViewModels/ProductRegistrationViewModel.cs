using SportsPro.Models.DomainModels;

namespace SportsPro.Models.ViewModels
{
    public class ProductRegistrationViewModel
    {
        public Customer? Customer { get; set; } = null!;
        public IEnumerable<Product>? Products { get; set; } = null!;
        public int? ProductId { get; set; } = 0;
    }
}
