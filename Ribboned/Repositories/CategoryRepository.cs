using Ribboned.Data;
using Ribboned.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _context.Category.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Category.FirstOrDefault(c => c.Id == id);
        }
    }
}
