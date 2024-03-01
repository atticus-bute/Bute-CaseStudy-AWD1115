using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechIncidentController : Controller
    {
        private const string TECH_KEY = "techId";
        private SportsProContext context { get; set; }
        public TechIncidentController(SportsProContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.Technicians = context.Technicians.Where(t=>t.TechnicianId > -1).OrderBy(t=>t.LastName).ToList();
            var technician = new Technician();
            int? techId = HttpContext.Session.GetInt32("techId");
            if (techId.HasValue)
            {
                technician = context.Technicians.Find(techId);
            }
            return View(technician);
        }
    }
}
