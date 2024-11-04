using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Entity
{
    public class signup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; } = true;

        //public string ImagePath { get; set; }
        [MaxLength(100)]
        public string ImagePath { get; set; }
    }
}
