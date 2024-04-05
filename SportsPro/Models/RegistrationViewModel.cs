namespace SportsPro.Models
{
    public class RegistrationViewModel
    {
        public Customer Customer { get; set; } = null!;
        public IEnumerable<Product> Products { get; set; } = null!;
    }
}
