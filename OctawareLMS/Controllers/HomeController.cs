using Microsoft.AspNetCore.Mvc;
using OctawareLMS.Data;
using OctawareLMS.Models;
using System.Diagnostics;

namespace OctawareLMS.Controllers
{
    public class HomeController : Controller
    {
        public static bool isLoggedIn=false;
        
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Index(int id)
        {
            if (isLoggedIn)
            {
                
                Employee employee = _context.employees.Where(temp => temp.Id == id).FirstOrDefault();
                return View(employee);
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