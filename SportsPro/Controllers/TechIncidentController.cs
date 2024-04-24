using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;
using SportsPro.Models.ViewModels;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TechIncidentController : Controller
    {
        private const string TECH_KEY = "techId";
        private Repository<Incident> incidents { get; set; }
        private Repository<Technician> technicians { get; set; }
        public TechIncidentController(SportsProContext ctx)
        {
            incidents = new Repository<Incident>(ctx);
            technicians = new Repository<Technician>(ctx);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var options = new QueryOptions<Technician>
            {
                OrderBy = t => t.LastName,
                Where = t => t.TechnicianId > -1
            };
            ViewBag.Technicians = technicians.List(options);
            var technician = new Technician();
            int? techId = HttpContext.Session.GetInt32("techId");
            if (techId.HasValue)
            {
                technician = technicians.Get(techId.Value);
            }
            return View(technician);
        }
        [HttpGet]
        public IActionResult List(int id)
        {
            var technician = technicians.Get(id);
            if (technician == null)
            {
                TempData["techincidentmessage"] = "Technician not found. Please select a technician.";
                return RedirectToAction("Index");
            }
            else
            {
                var options = new QueryOptions<Incident>
                {
                    Includes = "Customer, Product",
                    OrderBy = i => i.DateOpened,
                    Where = i => i.TechnicianId == id && i.DateClosed == null
                };
                var model = new TechIncidentViewModel
                {
                    Technician = technician,
                    Incidents = incidents.List(options)
                };
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult List(Technician technician)
        {
            if (technician.TechnicianId == 0)
            {
                TempData["techincidentmessage"] = "Please select a technician";
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetInt32(TECH_KEY, technician.TechnicianId);
                return RedirectToAction("List", new { id = technician.TechnicianId });
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
            var technician = technicians.Get(techId.Value);
            if (technician == null)
            {
                TempData["techincidentmessage"] = "Technician not found. Please select a technician.";
                return RedirectToAction("Index");
            }
            else
            {
                var options = new QueryOptions<Incident>
                {
                    Includes = "Customer, Product",
                    Where = i => i.IncidentId == id
                };
                var model = new TechIncidentViewModel
                {
                    Technician = technician,
                    Incident = incidents.Get(options)!
                };
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult Edit(TechIncidentViewModel model)
        {
            Incident i = incidents.Get(model.Incident.IncidentId)!;
            i.Description = model.Incident.Description;
            i.DateClosed = model.Incident.DateClosed;
            incidents.Update(i);
            incidents.Save();
            int? techId = HttpContext.Session.GetInt32(TECH_KEY);
            return RedirectToAction("List", new { id = techId });
        }
    }
}
