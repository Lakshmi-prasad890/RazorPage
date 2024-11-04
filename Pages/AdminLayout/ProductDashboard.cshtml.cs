using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data.dbcontext;
using WebApplication1.Data.Entity;
using System.Collections.Generic;

namespace WebApplication1.Pages.AdminLayout
{
    public class ProductDashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProductDashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Products> ProductList { get; set; } = new List<Products>();

        public void OnGet()
        {
            ProductList = _context.Products.ToList(); // Fetch products from the database
        }
        public IActionResult OnPostDelete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
