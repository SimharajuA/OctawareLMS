using System.ComponentModel.DataAnnotations;

namespace OctawareLMS.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please Enter a valid Id")]
        public int Id { get; set; }

        
        public string? Password { get; set; }
    }
}
