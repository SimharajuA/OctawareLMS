
using System.ComponentModel.DataAnnotations;

namespace OctawareLMS.Models
{
    public class LeaveRequestViewModel
    {

        [Required]
        [Display(Name ="Leave Type")]
        public string LeaveType { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public string Comment { get; set; }

    }
}
