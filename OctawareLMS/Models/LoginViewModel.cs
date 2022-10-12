using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OctawareLMS.Models
{
    
    public class LoginViewModel
    {
        [Required(ErrorMessage ="enter employee id")]
        public int? Id { get; set; }

        [Required(ErrorMessage ="enter password")]
        public string? Password { get; set; }
    }
}
