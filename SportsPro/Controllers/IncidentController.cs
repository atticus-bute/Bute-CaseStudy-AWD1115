using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using Microsoft.EntityFrameworkCore;
namespace SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext Context { get; set; }
        public IncidentController(SportsProContext ctx)
        {
            Context = ctx;
        }
        //HTTP GET METHODS
        [HttpGet]
        [Route("incidents/{filter?}")]
        public IActionResult Index(string filter = "all")
        {
            IncidentViewModel vm = new IncidentViewModel
            {
                Incidents = Context.Incidents.Include(i => i.Technician).Include(i => i.Customer).Include(i => i.Product).ToList()
            };
            ViewBag.Title = "Incidents";
            if (filter == "unassigned")
            {
                vm.Filter = "unassigned";
                vm.Incidents = Context.Incidents.Where(i => i.TechnicianId == -1).Include(i => i.Technician).Include(i => i.Customer).Include(i => i.Product).ToList();
            }
            else if (filter == "open")
            {
                vm.Filter = "open";
                vm.Incidents = Context.Incidents.Where(i => i.DateClosed == null).Include(i => i.Technician).Include(i => i.Customer).Include(i => i.Product).ToList();
            }
            else
            {
                vm.Filter = "all";
                vm.Incidents = Context.Incidents.Include(i => i.Technician).Include(i => i.Customer).Include(i => i.Product).ToList();
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult Add()
        {
            IncidentViewModel vm = new IncidentViewModel
            {
                Incident = new Incident(),
                Technicians = Context.Technicians.OrderBy(t => t.LastName).ToList(),
                Customers = Context.Customers.OrderBy(c => c.LastName).ToList(),
                Products = Context.Products.OrderBy(p => p.Name).ToList()
            };
            ViewBag.Action = "Add";
            return View("Edit", vm);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            IncidentViewModel vm = new IncidentViewModel
            {
                Incident = Context.Incidents.Find(id),
                Technicians = Context.Technicians.OrderBy(t => t.LastName).ToList(),
                Customers = Context.Customers.OrderBy(c => c.LastName).ToList(),
                Products = Context.Products.OrderBy(p => p.Name).ToList()
            };
            ViewBag.Action = "Edit";
            return View(vm);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = Context.Incidents.Find(id);
            return View(incident);
        }
        //HTTP POST METHODS
        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            IncidentViewModel vm = new IncidentViewModel
            {
                Incident = incident,
                Technicians = Context.Technicians.OrderBy(t => t.LastName).ToList(),
                Customers = Context.Customers.OrderBy(c => c.LastName).ToList(),
                Products = Context.Products.OrderBy(p => p.Name).ToList()
            };
            if (ModelState.IsValid)
            {
                if (vm.Incident.IncidentId == 0)
                {
                    vm.Incident.DateOpened = DateTime.Now;
                    Context.Incidents.Add(vm.Incident);
                }
                else
                {
                    Context.Incidents.Update(vm.Incident);
                }
                Context.SaveChanges();
                TempData["incidentmessage"] = $"Incident {vm.Incident.Title} has been saved";
                return RedirectToAction("Index", vm);
            }
            else
            {
                return View(vm);
            }
        }
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            Context.Incidents.Remove(incident);
            Context.SaveChanges();
            TempData["incidentmessage"] = $"Incident {incident.Title} has been deleted";
            return RedirectToAction("Index");
        }
    }
}
