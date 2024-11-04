using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data.dbcontext;
using WebApplication1.Pages.classes;

namespace WebApplication1.Pages
{
    public class AdminModel : PageModel
    {
       

        [BindProperty]
        public AdminForm newuser { get; set; }

      public string Email {  get; set; }    
        public string Password { get; set; }
        public void OnGet()
        {         
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            const string adminEmail = "lp@gmail.com";
            const string adminPassword = "121212";

            if (newuser.Email == adminEmail && newuser.Password == adminPassword)
            {
                TempData["AdminLoginMessage"] = "Login successful!";
                return RedirectToPage("AdminDashboard"); 
            }

          
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return Page();
        }
    }
}
