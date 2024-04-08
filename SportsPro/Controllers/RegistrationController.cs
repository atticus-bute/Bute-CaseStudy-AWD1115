using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class RegistrationController : Controller
    {
        private const string CUST_KEY = "custId";
        private SportsProContext Context { get; set; }
        public RegistrationController(SportsProContext ctx)
        {
            Context = ctx;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Customers = Context.Customers.Where(c => c.CustomerId > -1).OrderBy(c => c.LastName).ToList();
            var customer = new Customer();
            int? custId = HttpContext.Session.GetInt32("custId");
            if (custId.HasValue)
            {
                customer = Context.Customers.Find(custId);
            }
            return View(customer);
        }
        [HttpGet]
        public IActionResult Register(int id)
        {
            var customer = Context.Customers
                          .Include(c => c.RegisteredProducts)
                          .ThenInclude(cp => cp.RegisteredCustomers)
                          .FirstOrDefault(c => c.CustomerId == id);
            ;
            if (customer == null)
            {
                TempData["registrationmessage"] = "Customer not found. Please select a customer.";
                return RedirectToAction("Index");
            }
            else
            {
                var model = new RegistrationViewModel
                {
                    Customer = customer,
                    Products = Context.Products.ToList()
                };
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                TempData["registrationmessage"] = "Please select a customer.";
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetInt32(CUST_KEY, customer.CustomerId);
                return RedirectToAction("Register", new { id = customer.CustomerId });
            }
        }
    }
}
