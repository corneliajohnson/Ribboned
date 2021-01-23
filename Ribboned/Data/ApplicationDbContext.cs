using Microsoft.EntityFrameworkCore;
using Ribboned.Models;

namespace Ribboned.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Source> Source { get; set; }
        public DbSet<UserProfile> UserProfile {get; set;}
        public DbSet<Ribbon> Ribbon { get; set; }
        public DbSet<Snag> Snag { get; set; }
    }
}
