using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Data.Entity
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Description { get; set; }

        [StringLength(200)]
        public string ImagePath { get; set; } // Column in the database to store image path

        [NotMapped]
        public IFormFile ImageFile { get; set; } // Used for handling file uploads but not stored in the database
    }
}
