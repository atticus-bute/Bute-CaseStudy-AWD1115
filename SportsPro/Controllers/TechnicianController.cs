using Microsoft.AspNetCore.Mvc;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;

namespace SportsPro.Controllers
{
    public class TechnicianController : Controller
    {
        private Repository<Technician> technicians { get; set; }
        public TechnicianController(SportsProContext ctx)
        {
            technicians = new Repository<Technician>(ctx);
        }
        //HTTP GET METHODS
        [HttpGet]
        [Route("technicians")]
        public IActionResult Index()
        {
            return View(technicians.List(new QueryOptions<Technician>()));
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
            var technician = technicians.Get(id);
            return View(technician);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = technicians.Get(id);
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
                    technicians.Insert(technician);
                }
                else
                {
                    technicians.Update(technician);
                }
                technicians.Save();
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
            technicians.Delete(technician);
            technicians.Save();
            TempData["technicianmessage"] = $"Technician {technician.FullName} has been deleted";
            return RedirectToAction("Index");
        }
    }
}
