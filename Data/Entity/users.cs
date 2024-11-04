using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entity
{
    public class users
    {
        [Key]
        public int id {  get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required,MaxLength (100)]
        public string Email { get; set; }
    }
}
