using Microsoft.AspNetCore.Mvc;
using OctawareLMS.Data;
using OctawareLMS.Models;
using System.Diagnostics;

namespace OctawareLMS.Controllers
{
    public class HomeController : Controller
    {
        public static bool isLoggedIn=false;
       
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
           
            this._context = context;
        }

        public IActionResult Index(int? id)
        {
            if (isLoggedIn)
            {
                try
                {
                    Employee employee = _context.employees.Where(temp => temp.Id == id).FirstOrDefault();
                    ViewBag.id = id;
                    if(employee == null)
                    {
                        TempData["invalid"] = "Please provide Valid Employee Id and Password";
                        return RedirectToAction("Login");
                    }
                    return View(employee);

                }
                catch(NullReferenceException ex)
                {
                    isLoggedIn = false;
                    
                    return RedirectToAction("Login");
                }
                

            }
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                isLoggedIn = true;
               
                return RedirectToAction("Index",new { id = loginViewModel.Id });
            }
           
           return View(loginViewModel);   
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