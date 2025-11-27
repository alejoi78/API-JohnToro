using API_JohnToro.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace API_JohnToro.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
    