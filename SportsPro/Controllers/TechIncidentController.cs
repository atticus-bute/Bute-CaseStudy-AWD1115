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
        [HttpGet]
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
        [HttpPost]
        public IActionResult List(Technician technician)
        {
            if(technician.TechnicianId == 0)
            {
                TempData["techincidentmessage"] = "Please select a technician";
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetInt32(TECH_KEY, technician.TechnicianId);
                return RedirectToAction("List", new { id = technician.TechnicianId});
            }
        }
        [HttpGet]
        public IActionResult List(int id)
        {
            var technician = context.Technicians.Find(id);
            if (technician == null)
            {
                TempData["techincidentmessage"] = "Technician not found. Please select a technician.";
                return RedirectToAction("Index");
            }
            else
            {
                var model = new TechIncidentViewModel
                {
                    Technician = technician,
                    Incidents = context.Incidents.Include(i => i.Customer).Include(i => i.Product).OrderBy(i => i.DateOpened).Where(i => i.TechnicianId == id).Where(i => i.DateClosed == null).ToList()
                };
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            int? techId = HttpContext.Session.GetInt32(TECH_KEY);
            if (!techId.HasValue)
            {
                TempData["techincidentmessage"] = "Technician not found. Please select a technician.";
                return RedirectToAction("Index");
            }
            var technician = context.Technicians.Find(techId);
            if (technician == null)
            {
                TempData["techincidentmessage"] = "Technician not found. Please select a technician.";
                return RedirectToAction("Index");
            }
            else
            {
                var model = new TechIncidentViewModel
                {
                    Technician = technician,
                    Incident = context.Incidents.Include(i => i.Customer).Include(i => i.Product).FirstOrDefault(i => i.IncidentId == id)!
                };
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult Edit(TechIncidentViewModel model)
        {
            Incident i = context.Incidents.Find(model.Incident.IncidentId)!;
            i.Description = model.Incident.Description;
            i.DateClosed = model.Incident.DateClosed;
            context.Incidents.Update(i);
            context.SaveChanges();
            int? techId = HttpContext.Session.GetInt32(TECH_KEY);
            return RedirectToAction("List", new { id = techId });
        }
    }
}
