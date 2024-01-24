using MainE_Learning.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MainE_Learning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Add logic for handling login
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Register(string fullname, string username, string password)
        {
            // Add logic for handling registration
            return RedirectToAction("Index");
        }
    

    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}