using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Data.Entity;

namespace WebApplication1.Pages.classes
{
    public class SignUp
    {
        [Required(ErrorMessage = "UserName required")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Password must be atleast 6 characters", MinimumLength = 6)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password not match")]
        public string ConfirmPassword { get; set; }

        //public string ImagePath {  get; set; }
        
        public IFormFile ImageFile { get; set; }
    }

}
