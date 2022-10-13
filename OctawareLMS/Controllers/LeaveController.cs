using Microsoft.AspNetCore.Mvc;
using OctawareLMS.Data;
using OctawareLMS.Models;

namespace OctawareLMS.Controllers
{
    public class LeaveController : Controller
    {
        public static int employeeId;
        private readonly ApplicationDbContext _context;

        public LeaveController(ApplicationDbContext context)
        {
            this._context = context;
        }

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
            employeeId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Apply(LeaveRequestViewModel leaveRequestViewModel)
        {
            //action method will insert a row into leave request table with specified information
            ViewBag.id = employeeId;
            int id = employeeId;
            if (!ModelState.IsValid)
            {
                return View(leaveRequestViewModel);
            }
           LeaveRequest leaveRequest = new LeaveRequest();
            
            leaveRequest.Employee = _context.employees.Where(temp => temp.Id == id).FirstOrDefault();
            leaveRequest.StartDate = leaveRequestViewModel.StartDate;
            leaveRequest.EndDate=leaveRequestViewModel.EndDate;
            leaveRequest.LeaveType = leaveRequestViewModel.LeaveType;
            leaveRequest.Status = "pending";
            leaveRequest.Comment = leaveRequestViewModel.Comment;
            if (leaveRequestViewModel.StartDate.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("invaliddate", "Start Date should not be in past");
                return View(leaveRequestViewModel);  
            }
            if (leaveRequestViewModel.EndDate.Date < leaveRequestViewModel.StartDate.Date)
            {
                ModelState.AddModelError("invaliddate", "End Date should not be less than Start Date");
                return View(leaveRequestViewModel);
            }

            leaveRequest.NumberOfDays = Convert.ToInt32((leaveRequestViewModel.EndDate - leaveRequestViewModel.StartDate).TotalDays);
            _context.leaveRequests.Add(leaveRequest);
            _context.SaveChanges();

            TempData["Message"] = "Successfully Raised a Leave request, waiting to be approved by your manager";
            return RedirectToAction("LeaveStatus", new { id = id });
        }


        public IActionResult LeaveStatus(int id)
        {
            //this action method will retrive all his leave request that he raised based in employee id
            List<LeaveRequest> leave = _context.leaveRequests.Where(temp => temp.Employee.Id == id).OrderByDescending(temp => temp.EndDate).ToList();


            ViewBag.id = id;
            return View(leave);
        }

}
}
