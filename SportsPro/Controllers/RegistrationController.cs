using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;
using SportsPro.Models.ViewModels;

namespace SportsPro.Controllers
{
    public class RegistrationController : Controller
    {
        private const string CUST_KEY = "custId";
        private Repository<Customer> customers { get; set; }
        private Repository<Product> products { get; set; }
        public RegistrationController(SportsProContext ctx)
        {
            customers = new Repository<Customer>(ctx);
            products = new Repository<Product>(ctx);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var options = new QueryOptions<Customer>
            {
                OrderBy = c => c.LastName,
                Where = c => c.CustomerId > -1
            };
            ViewBag.Customers = customers.List(options);
            var customer = new Customer();
            int? custId = HttpContext.Session.GetInt32("custId");
            if (custId.HasValue)
            {
                customer = customers.Get(custId.Value);
            }
            return View(customer);
        }
        [HttpGet]
        public IActionResult Register(int id)
        {
            var options = new QueryOptions<Customer>
            {
                Includes = "RegisteredProducts.RegisteredCustomers",
                Where = c => c.CustomerId == id
            };
            var customer = customers.Get(options);
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
                    Products = products.List(new QueryOptions<Product>())
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
        [HttpPost]
        public IActionResult Add(RegistrationViewModel model)
        {
            var options = new QueryOptions<Customer>
            {
                Includes = "RegisteredProducts",
                Where = c => c.CustomerId == model.Customer.CustomerId
            };
            var customer = customers.Get(options);

            if (customer != null)
            {
                var product = products.Get(model.ProductId.Value);
                if (product != null)
                {
                    customer.RegisteredProducts.Add(product);
                    customers.Save();
                    TempData.Add("registrationmessage", "Product added");
                }
            }
            return RedirectToAction("Register", new { id = model.Customer.CustomerId });
        }

        [HttpPost]
        public IActionResult Delete(int id, int productId)
        {
            var custOptions = new QueryOptions<Customer>
            {
                Includes = "RegisteredProducts",
                Where = c => c.CustomerId == id
            };
            var customer = customers.Get(custOptions);

            if (customer != null)
            {
                var product = customer.RegisteredProducts.FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    customer.RegisteredProducts.Remove(product);
                    customers.Save();
                    TempData.Add("registrationmessage", "Product removed");
                    return RedirectToAction("Register", new { id = id });
                }
                TempData.Add("registrationmessage", "Product not found");
                return RedirectToAction("Register", new { id = id });
            }
            return RedirectToAction("Register", new { id = id });
        }
    }
}
