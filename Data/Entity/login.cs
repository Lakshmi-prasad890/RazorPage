using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Entity
{
    public class login
    {
        [Key]
        public int Id { get; set; }
      
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LoginTime { get; internal set; }
        public bool IsSuccessful { get; internal set; }
    }
}
