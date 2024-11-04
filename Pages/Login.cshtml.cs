using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data.dbcontext;
using WebApplication1.Pages.classes;

namespace WebApplication1.Pages
{
    public class LoginModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [BindProperty]
        public LoginForm newuser { get; set; }
       /* [BindProperty]
        public string CourseList { get; set; }
        public List<SelectListItem> CourseOptions { get; set; }*/
        public void OnGet()
        {/*
            CourseOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "course1", Text = "Course 1" },
                new SelectListItem { Value = "course2", Text = "Course 2" },
                new SelectListItem { Value = "course3", Text = "Course 3" }
            };*/
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var authUser = _context.signup.FirstOrDefault(u => u.Email == newuser.Email && u.Password == newuser.Password);

            var login = new Data.Entity.login
            {
                Email = newuser.Email,
                Password=newuser.Password,
                LoginTime = DateTime.Now,
                IsSuccessful = authUser != null
            };

            _context.login.Add(login);
            _context.SaveChanges();

            if (authUser != null)
            {
                TempData["login"] = "Logged in successfully.";
                return RedirectToPage("ProductDashboard");
            }
            else
            {
                TempData["error"] = "Invalid email or password.";
                return Page();
            }
        }

        /*Console.WriteLine($"Name:{newuser.Name}, Email:{newuser.Email}, Password:{newuser.Password}");
            TempData["login"] = "logined sucessfully....";
            return RedirectToPage("common");
*/
        //public void OnPostSend()
        //{
        //    if (!string.IsNullOrWhiteSpace(newuser.Name) &&
        //   !string.IsNullOrWhiteSpace(newuser.Email) &&
        //   !string.IsNullOrWhiteSpace(newuser.Password) &&
        //   !string.IsNullOrWhiteSpace(newuser.CourseList)) 
        //    {

        //Console.WriteLine($"Name:{newuser.Name}, Email:{newuser.Email}, Password:{newuser.Password},CourseList:{newuser.CourseList}");

        //    }
        //    else
        //    {
        //        Console.WriteLine("All the fields are required to be entered");
        //    }
        //}

    }
}
