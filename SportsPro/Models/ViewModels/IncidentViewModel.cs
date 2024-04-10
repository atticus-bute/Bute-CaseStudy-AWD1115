using SportsPro.Models.DomainModels;

namespace SportsPro.Models.ViewModels
{
    public class IncidentViewModel
    {
        public Incident? Incident { get; set; }
        public IEnumerable<Incident>? Incidents { get; set; }
        public IEnumerable<Technician>? Technicians { get; set; }
        public IEnumerable<Customer>? Customers { get; set; }
        public IEnumerable<Product>? Products { get; set; }
        public string? Filter { get; set; }
        public string? Action { get; set; }
    }
}
