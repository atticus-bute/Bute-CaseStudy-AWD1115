using System.ComponentModel.DataAnnotations;
namespace SportsPro.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime? DateOpened { get; set; } = null;
        public DateTime? DateClosed { get; set; } = null;
    }
}
