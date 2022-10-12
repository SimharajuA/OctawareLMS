using System.ComponentModel.DataAnnotations;

namespace OctawareLMS.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateOfJoining { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public int ManagerId { get; set; }
    }
}
