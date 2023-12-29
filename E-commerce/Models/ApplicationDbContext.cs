using Microsoft.EntityFrameworkCore;
using E_commerce.Models;

namespace E_commerce.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

     
        public DbSet<Product>products { get; set; }
        public DbSet<Users>users { get; set; }
        public DbSet<Categoty> cat { get; set; }
    }
}
