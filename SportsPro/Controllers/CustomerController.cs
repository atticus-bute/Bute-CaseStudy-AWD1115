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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Customer());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
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
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
                return View(customer);
            }
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            Context.Customers.Remove(customer);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
