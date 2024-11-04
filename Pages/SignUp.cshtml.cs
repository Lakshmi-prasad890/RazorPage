using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data.dbcontext;
using WebApplication1.Data.Entity;
using WebApplication1.Entity;
using WebApplication1.Pages.classes;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
namespace WebApplication1.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public SignUpModel(ApplicationDbContext dbContext,IWebHostEnvironment _env)
        {
            _context = dbContext;
            _environment = _env;
        }


        [BindProperty]
        public  SignUp newuser { get; set; }
       
       
        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string fileName = null;
            if (newuser.ImageFile != null)
            {
                // Generate a unique file name
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(newuser.ImageFile.FileName);

                // Set the path to save the file in wwwroot/Upload
                var filePath = Path.Combine(_environment.WebRootPath, "Upload", fileName);

                // Ensure that the Upload directory exists
                Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "Upload"));

                // Save the file asynchronously
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newuser.ImageFile.CopyToAsync(fileStream);
                }
            }


            var newUser = new signup
            {

                Name = newuser.Name,
                Email = newuser.Email,
                Password = newuser.Password,
                ConfirmPassword = newuser.ConfirmPassword,
                ImagePath = fileName
            };
            //_context.signup.Add(newUser);
            //await _context.SaveChangesAsync();

            _context.signup.Add(newUser);
            _context.SaveChanges();

            if (!ModelState.IsValid)
            {
                return Page();
            }
            TempData["message"] = "Sign-up successful! Please log in.";

            return RedirectToPage("common");

        }

        /*public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TempData["message"] = "Sign-up successful! Please log in.";

            return RedirectToPage("common");
        }*/



    }
}
