using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages.classes
{
    public class AdminForm
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password must be at least 6 characters.", MinimumLength = 6)]
        public string Password {  get; set; }
    }
}
