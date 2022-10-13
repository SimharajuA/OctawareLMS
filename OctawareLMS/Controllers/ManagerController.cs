using Microsoft.AspNetCore.Mvc;
using OctawareLMS.Data;
using OctawareLMS.Models;

namespace OctawareLMS.Controllers
{
    public class ManagerController : Controller
    {
       

        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
           
            this._context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Details(int id)
        {
           int managerId = _context.employees.Where(temp=>temp.Id == id).FirstOrDefault().ManagerId;
            if(managerId == null)
            {
                return NotFound();
            }
            Employee manager = _context.employees.Where(temp => temp.Id == managerId).FirstOrDefault();
            ViewBag.id=id;
            return View(manager);
        }
    }
}
