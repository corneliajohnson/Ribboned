using Ribboned.Data;
using Ribboned.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ribboned.Repositories
{
    public class SourceRepository : ISourceRepository
    {
        private readonly ApplicationDbContext _context;

        public SourceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Source> GetAll()
        {
            return _context.Source.ToList();
        }
    }
}
