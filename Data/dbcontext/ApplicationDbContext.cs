using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using WebApplication1.Data.Entity;
using WebApplication1.Entity;
using WebApplication1.Pages.classes;

namespace WebApplication1.Data.dbcontext
{
    public class ApplicationDbContext : DbContext 
    {

      
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {

        }   
        public DbSet<users> users { get; set; }
        public DbSet<signup> signup { get; set; }
        public DbSet<login> login { get; set; }
        public DbSet<Products> Products { get; set; }

    }

}
