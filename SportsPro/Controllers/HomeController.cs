using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System.Diagnostics;

namespace SportsPro.Controllers
{
    public class HomeController : Controller
    {
        private SportsProContext Context { get; set; }
        public HomeController(SportsProContext ctx)
        {
            Context = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
