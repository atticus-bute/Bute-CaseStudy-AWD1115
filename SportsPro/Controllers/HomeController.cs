using Microsoft.AspNetCore.Mvc;
using SportsPro.Models.DataLayer;
using System.Diagnostics;

namespace SportsPro.Controllers
{
    public class HomeController : Controller
    {
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
