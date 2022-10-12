using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctawareLMS.Models
{
    public class LeaveBalance
    {
        [Key]
        public int Id { get; set; }

        public Employee Employee { get; set; }

        public int LeaveBalanceCount { get; set; } = 30;  

    }
}
