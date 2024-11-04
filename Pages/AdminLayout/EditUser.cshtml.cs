using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data.dbcontext;
using WebApplication1.Data.Entity;

namespace WebApplication1.Pages.AdminLayout
{
    public class EditUserModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditUserModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public signup User { get; set; }

        public IActionResult OnGet(int id)
        {
            User = _context.signup.Find(id);
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostEditSave(int Id)
        {

            var userToUpdate = _context.signup.Find(User.Id);
            if (userToUpdate == null)
            {
                return NotFound();
            }

            userToUpdate.Name = User.Name;
            userToUpdate.Email = User.Email;
            userToUpdate.Password = User.Password;

            _context.SaveChanges();

            return RedirectToPage("/AdminDashboard");
        }
    }
}