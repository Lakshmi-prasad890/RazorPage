using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages.classes
{
    public class LoginForm
    {
        [Required(ErrorMessage = "Error")]
        
       /* public string Name { get; set; }
        [Required]*/
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password must be atleast 6 characters", MinimumLength = 6)]
        public string Password { get; set; }
       
    }
}
