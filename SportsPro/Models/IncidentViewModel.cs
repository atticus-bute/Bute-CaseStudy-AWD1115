﻿namespace SportsPro.Models
{
    public class IncidentViewModel
    {
        public Incident? Incident { get; set; }
        public List<Incident>? Incidents { get; set; }
        public List<Technician>? Technicians { get; set; }
        public List<Customer>? Customers { get; set; }
        public List<Product>? Products { get; set; }
        public string? Filter { get; set; }
        public string? Action { get; set; }
    }
}