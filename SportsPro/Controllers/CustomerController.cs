using Microsoft.AspNetCore.Mvc;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;
namespace SportsPro.Controllers
{
    public class CustomerController : Controller
    {
        private Repository<Customer> customers { get; set; }
        private Repository<Country> countries { get; set; }
        public CustomerController(SportsProContext ctx)
        {
            customers = new Repository<Customer>(ctx);
            countries = new Repository<Country>(ctx);
        }
        //HTTP GET METHODS
        [HttpGet]
        [Route("customers")]
        public IActionResult Index()
        {
            return View(customers.List(new QueryOptions<Customer>()));
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = countries.List(new QueryOptions<Country>());
            return View("Edit", new Customer());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = countries.List(new QueryOptions<Country>());
            var customer = customers.Get(id);
            return View(customer);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = customers.Get(id);
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
                    customers.Insert(customer);
                }
                else
                {
                    customers.Update(customer);
                }
                ViewBag.Countries = countries.List(new QueryOptions<Country>());
                customers.Save();
                TempData["customermessage"] = $"Customer {customer.FullName} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
                ViewBag.Countries = countries.List(new QueryOptions<Country>());
                return View(customer);
            }
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            customers.Delete(customer);
            customers.Save();
            TempData["customermessage"] = $"Customer {customer.FullName} has been deleted";
            return RedirectToAction("Index");
        }
    }
}
