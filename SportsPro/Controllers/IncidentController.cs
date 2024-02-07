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
        public IActionResult Index()
        {
            var incidents = Context.Incidents.Include(i => i.Technician).Include(i => i.Customer).Include(i => i.Product).ToList();
            ViewBag.Title = "Incidents";
            return View(incidents);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Incident());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var incident = Context.Incidents.Find(id);
            return View(incident);
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
            if (ModelState.IsValid)
            {
                if (incident.IncidentId == 0)
                {
                    Context.Incidents.Add(incident);
                }
                else
                {
                    Context.Incidents.Update(incident);
                }
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (incident.IncidentId == 0) ? "Add" : "Edit";
                return View(incident);
            }
        }
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            Context.Incidents.Remove(incident);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
