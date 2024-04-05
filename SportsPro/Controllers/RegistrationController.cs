using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class RegistrationController : Controller
    {
        private SportsProContext Context { get; set; }
        public RegistrationController(SportsProContext ctx)
        {
            Context = ctx;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Customers = Context.Customers.Where(c => c.CustomerId > -1).OrderBy(c => c.LastName).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Register(Customer customer)
        {
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
    }
}
