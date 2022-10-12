using Microsoft.EntityFrameworkCore;
using OctawareLMS.Models;

namespace OctawareLMS.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }

        public DbSet<LeaveBalance> leaveBalances { get; set; }

        public DbSet<LeaveRequest> leaveRequests { get; set; }  
    }
}
