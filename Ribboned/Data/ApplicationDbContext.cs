using Microsoft.EntityFrameworkCore;
using Ribboned.Models;

namespace Ribboned.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Category{ get; set; }   
        public DbSet<Source> Source { get; set; }
    }
}
