using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechnicianController : Controller
    {
        private SportsProContext Context { get; set; }
        public TechnicianController(SportsProContext ctx)
        {
            Context = ctx;
        }
        //HTTP GET METHODS
        [HttpGet]
        [Route("technicians")]
        public IActionResult Index()
        {
            var technicians = Context.Technicians.OrderBy(t => t.LastName).ToList();
            ViewBag.Title = "Technicians";
            return View(technicians);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = Context.Technicians.Find(id);
            return View(technician);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = Context.Technicians.Find(id);
            return View(technician);
        }
        //HTTP POST METHODS
        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                if (technician.TechnicianId == 0)
                {
                    Context.Technicians.Add(technician);
                }
                else
                {
                    Context.Technicians.Update(technician);
                }
                Context.SaveChanges();
                TempData["technicianmessage"] = $"Technician {technician.FullName} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (technician.TechnicianId == 0) ? "Add" : "Edit";
                return View(technician);
            }
        }
        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            Context.Technicians.Remove(technician);
            Context.SaveChanges();
            TempData["technicianmessage"] = $"Technician {technician.FullName} has been deleted";
            return RedirectToAction("Index");
        }
    }
}
