using Microsoft.AspNetCore.Mvc;
using MyGreetingsMVC.Models;

namespace MyGreetingsMVC.Controllers
{
    public class HomeController : Controller
    {
        // Displays the input page
        public IActionResult Index()
        {
            return View();
        }

        // Receives the submitted name
        [HttpPost]
        public IActionResult Greeting(GreetingModel model)
        {
            return View(model);
        }
    }
}