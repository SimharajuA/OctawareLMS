using Microsoft.AspNetCore.Mvc;
using OctawareLMS.Models;
using System.Diagnostics;

namespace OctawareLMS.Controllers
{
    public class HomeController : Controller
    {
        public static bool isLoggedIn=false;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            if (isLoggedIn)
            {
                return View();
            }

            return RedirectToAction("Login");
        }
        
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!loginViewModel.Id.Equals(null))
            {
                isLoggedIn = true;

                RedirectToAction("Index",new { id = loginViewModel.Id });
            }
           
            return View();
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