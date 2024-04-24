using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models.DomainModels;
using SportsPro.Models.DataLayer;
using SportsPro.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IncidentController : Controller
    {
        private Repository<Incident> incidents { get; set; }
        private Repository<Technician> technicians { get; set; }
        private Repository<Customer> customers { get; set; }
        private Repository<Product> products { get; set; }
        public IncidentController(SportsProContext ctx)
        {
            incidents = new Repository<Incident>(ctx);
            technicians = new Repository<Technician>(ctx);
            customers = new Repository<Customer>(ctx);
            products = new Repository<Product>(ctx);
        }
        //HTTP GET METHODS
        [HttpGet]
        [Route("incidents/{filter?}")]
        public IActionResult Index(string filter = "all")
        {
            var options = new QueryOptions<Incident>
            {
                Includes = "Technician, Customer, Product",
                OrderBy = i => i.DateOpened
            };
            ViewBag.Title = "Incidents";
            if (filter == "unassigned")
            {
                options.Where = i => i.TechnicianId == -1;
            }
            else if (filter == "open")
            {
                options.Where = i => i.DateClosed == null;
            }
            IncidentViewModel vm = new IncidentViewModel
            {
                Incidents = incidents.List(options),
                Technicians = technicians.List(new QueryOptions<Technician>()),
                Customers = customers.List(new QueryOptions<Customer>()),
                Products = products.List(new QueryOptions<Product>()),
                Filter = filter
            };
            return View(vm);
        }
        [HttpGet]
        public IActionResult Add()
        {
            IncidentViewModel vm = new IncidentViewModel
            {
                Incident = new Incident(),
                Technicians = technicians.List(new QueryOptions<Technician>()),
                Customers = customers.List(new QueryOptions<Customer>()),
                Products = products.List(new QueryOptions<Product>())
            };
            ViewBag.Action = "Add";
            return View("Edit", vm);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            IncidentViewModel vm = new IncidentViewModel
            {
                Incident = incidents.Get(id),
                Technicians = technicians.List(new QueryOptions<Technician>()),
                Customers = customers.List(new QueryOptions<Customer>()),
                Products = products.List(new QueryOptions<Product>())
            };
            ViewBag.Action = "Edit";
            return View(vm);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = incidents.Get(id);
            return View(incident);
        }
        //HTTP POST METHODS
        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            IncidentViewModel vm = new IncidentViewModel
            {
                Incident = incident,
                Technicians = technicians.List(new QueryOptions<Technician>()),
                Customers = customers.List(new QueryOptions<Customer>()),
                Products = products.List(new QueryOptions<Product>())
            };
            if (ModelState.IsValid)
            {
                if (vm.Incident.IncidentId == 0)
                {
                    vm.Incident.DateOpened = DateTime.Now;
                    incidents.Insert(vm.Incident);
                }
                else
                {
                    incidents.Update(vm.Incident);
                }
                incidents.Save();
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
            incidents.Delete(incident);
            incidents.Save();
            TempData["incidentmessage"] = $"Incident {incident.Title} has been deleted";
            return RedirectToAction("Index");
        }
    }
}
