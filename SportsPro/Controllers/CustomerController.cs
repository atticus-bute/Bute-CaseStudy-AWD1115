using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
namespace SportsPro.Controllers
{
    public class CustomerController : Controller
    {
        private SportsProContext Context { get; set; }
        public CustomerController(SportsProContext ctx)
        {
            Context = ctx;
        }
        //HTTP GET METHODS
        [HttpGet]
        [Route("customers")]
        public IActionResult Index()
        {
            var customers = Context.Customers.ToList();
            ViewBag.Title = "Customers";
            return View(customers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = Context.Countries.ToList();
            return View("Edit", new Customer());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = Context.Countries.ToList();
            var customer = Context.Customers.Find(id);
            return View(customer);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = Context.Customers.Find(id);
            return View(customer);
        }
        //HTTP POST METHODS
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    Context.Customers.Add(customer);
                }
                else
                {
                    Context.Customers.Update(customer);
                }
                ViewBag.Countries = Context.Countries.ToList();
                Context.SaveChanges();
                TempData["customermessage"] = $"Customer {customer.FullName} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
                ViewBag.Countries = Context.Countries.ToList();
                return View(customer);
            }
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            Context.Customers.Remove(customer);
            Context.SaveChanges();
            TempData["customermessage"] = $"Customer {customer.FullName} has been deleted";
            return RedirectToAction("Index");
        }
    }
}
