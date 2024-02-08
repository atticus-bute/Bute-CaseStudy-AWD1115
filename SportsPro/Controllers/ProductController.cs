using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext Context { get; set; }
        public ProductController(SportsProContext ctx)
        {
            Context = ctx;
        }
        //HTTP GET METHODS
        [HttpGet]
        [Route("products")]
        public IActionResult Index()
        {
            var products = Context.Products.ToList();
            ViewBag.Title = "Products";
            return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = Context.Products.Find(id);
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = Context.Products.Find(id);
            return View(product);
        }
        //HTTP POST METHODS
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                {
                    Context.Products.Add(product);
                }
                else
                {
                    Context.Products.Update(product);
                }
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (product.ProductId == 0) ? "Add" : "Edit";
                return View(product);
            }
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            Context.Products.Remove(product);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
