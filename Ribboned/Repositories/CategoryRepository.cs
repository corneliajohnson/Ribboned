using Microsoft.EntityFrameworkCore;
using Ribboned.Data;
using Ribboned.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ribboned.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Category.Include(c => c.UserProfile).ToList();
        }
    }
}
