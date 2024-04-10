using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace SportsPro.Models.DomainModels
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime? DateOpened { get; set; } = null;
        public DateTime? DateClosed { get; set; } = null;
        public int CustomerId { get; set; } = 0;
        [ValidateNever]
        public Customer Customer { get; set; } = null!;
        public int ProductId { get; set; } = 0;
        [ValidateNever]
        public Product Product { get; set; } = null!;
        public int TechnicianId { get; set; } = 0;
        [ValidateNever]
        public Technician Technician { get; set; } = null!;
    }
}
