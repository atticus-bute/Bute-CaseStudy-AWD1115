using Microsoft.AspNetCore.Mvc;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;
namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> products { get; set; }
        public ProductController(SportsProContext ctx) => products = new Repository<Product>(ctx);
        //HTTP GET METHODS
        [HttpGet]
        [Route("products")]
        public ViewResult Index()
        {
            return View(products.List(new QueryOptions<Product>()));
        }
        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = products.Get(id);
            return View(product);
        }
        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = products.Get(id);
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
                    products.Insert(product);
                }
                else
                {
                    products.Update(product);
                }
                products.Save();
                TempData["productmessage"] = $"Product {product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (product.ProductId == 0) ? "Add" : "Edit";
                return View(product);
            }
        }
        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            products.Delete(product);
            products.Save();
            TempData["productmessage"] = $"Product {product.Name} has been deleted";
            return RedirectToAction("Index");
        }
    }
}
