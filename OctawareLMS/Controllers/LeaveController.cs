using Microsoft.AspNetCore.Mvc;

namespace OctawareLMS.Controllers
{
    public class LeaveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Apply(int id)
        {
            //action method will show the view wich has form to apply for leave  
            //create appriote view model and take data from form and
            //assigne view model values to leave request type and insert the row into db using post method given below

            ViewBag.id=id;
            return View();
        }

        [HttpPost]
        public IActionResult Apply(int id, int dd)
        {
            //action method will insert a row into leave request table with specified information 
            

            ViewBag.id = id;
            return View();
        }


        public IActionResult LeaveStatus(int id)
        { 
            //this action method will retrive all his leave request that he raised based in employee id

            ViewBag.id = id;
            return View();
        }


        //we can create a new controller for this below method and scaffoled everything 
        public IActionResult ReportingEmployeesLeaves(int id)
        {
            //this action method will retrive all leave request received to him

            ViewBag.id = id;
            return View();
    }
}
}
