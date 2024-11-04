using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.dbcontext;
using WebApplication1.Data.Entity;

namespace WebApplication1.Pages.AdminLayout
{
    public class AdminDashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminDashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<signup> Users { get; set; } = new List<signup>();
        public List<Products> Products { get; set; } = new List<Products>();

        public void OnGet()
        {
            Users = _context.signup.ToList();
            Products = _context.Products.ToList();
        }

        public IActionResult OnPostDeleteUser(int id)
        {
            var user = _context.signup.Find(id);
            if (user != null)
            {
                _context.signup.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }


        public IActionResult OnPostUpdate(int id)
        {
            /*  var user = _context.signup.FirstOrDefault(u => u.Id == id);*/
            var user = _context.signup.Find(id);
            if (user != null)
            {
                // Toggle the IsActive status
                user.IsActive = !user.IsActive;
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
        public IActionResult OnPostEdit(int id)
        {
            var user = _context.signup.Find(id);
            if (user != null)
            {
                return RedirectToPage("EditUser", new { id });
            }
            return Page();
        }

    }
}



