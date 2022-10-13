using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OctawareLMS.Data;
using OctawareLMS.Models;

namespace OctawareLMS.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public static int EmpId;

        public LeaveRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveRequests
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.id = id;
            EmpId = id;
            //_context.leaveRequests.ToListAsync()
            List<LeaveRequest> leaveRequest = await _context.leaveRequests.Where(temp => temp.Employee.ManagerId == id).ToListAsync();
            //List<Employee> employee = new List<Employee>();
            //foreach(var item in leaveRequest)
            //{
            //        employee.Add(_context.leaveRequests.Where(temp => temp.Id == item.Id).FirstOrDefault().Employee);
                
            //}
            //ViewBag.employee = employee;
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.id = EmpId;


            if (id == null || _context.leaveRequests == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.leaveRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
     

        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            ViewBag.id = EmpId;

            if (id == null || _context.leaveRequests == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.leaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Status")] LeaveRequest leaveRequest)
        {
            ViewBag.id = EmpId;


            if (id != leaveRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new {id=EmpId});
            }
            return View(leaveRequest);
        }

       
        public IActionResult Approve(int id)
        {
            LeaveRequest leaveRequest = _context.leaveRequests.Where(temp=>temp.Id == id).FirstOrDefault();
            leaveRequest.Status = "approved";
            _context.Update(leaveRequest);
            //LeaveBalance leaveBalance = _context.leaveBalances.Where(temp => temp.Employee.Id == leaveRequest.Employee.Id).FirstOrDefault();
            //leaveBalance.LeaveBalanceCount = leaveBalance.LeaveBalanceCount - leaveRequest.NumberOfDays;
            //_context.Update(leaveBalance);
            _context.SaveChanges(); 

            return RedirectToAction("Index", new { id = EmpId });
        }

        
        public IActionResult Reject(int id)
        {
            LeaveRequest leaveRequest = _context.leaveRequests.Where(temp => temp.Id == id).FirstOrDefault();
            leaveRequest.Status = "rejected";
            _context.Update(leaveRequest);
            _context.SaveChanges();

            return RedirectToAction("Index", new { id = EmpId });
        }



        private bool LeaveRequestExists(int id)
        {
          return _context.leaveRequests.Any(e => e.Id == id);
        }
    }
}
