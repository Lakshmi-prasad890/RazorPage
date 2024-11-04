using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting; 
using WebApplication1.Data.dbcontext;
using WebApplication1.Data.Entity;
using System.IO;
using System.Threading.Tasks; 

namespace WebApplication1.Pages
{
    public class AddProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment; 

        public AddProductModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Products NewProduct { get; set; } = new Products();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() // Changed to async
        {
           

            // File upload logic
            string uniqueFileName = null;
            if (NewProduct.ImageFile != null)
            {
                // Generate a unique file name
                uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(NewProduct.ImageFile.FileName);

                // Set the path to save the file in wwwroot/ProductImages
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "ProductImages");
                Directory.CreateDirectory(uploadsFolder); // Ensure the directory exists

                // Save the file asynchronously
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await NewProduct.ImageFile.CopyToAsync(fileStream); // Use async file copy
                }

                NewProduct.ImagePath = "/ProductImages/" + uniqueFileName; // Set the image path
            }

            // Add the new product to the context
            _context.Products.Add(NewProduct);
            await _context.SaveChangesAsync(); // Save changes asynchronously

            return RedirectToPage("AdminDashboard"); // Redirect to Admin Dashboard
        }
    }
}
