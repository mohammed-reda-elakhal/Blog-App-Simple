using Blog_App_Simple.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_App_Simple.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<category> Categories { get; set; }


    }
}
