using Microsoft.EntityFrameworkCore;
using Ribboned.Data;
using Ribboned.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ribboned.Repositories
{
    public class SnagRepository : ISnagRepository
    {
        private readonly ApplicationDbContext _context;

        public SnagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Snag> GetByRibbon(int ribbonId)
        {
            return _context.Snag.Where(s => s.RibbonId == ribbonId).ToList();
        }

        public Snag GetById(int id)
        {
            return _context.Snag
                .FirstOrDefault(s => s.Id == id);
        }

        public void Add(Snag snag)
        {
            _context.Add(snag);
            _context.SaveChanges();
        }

        public void Update(Snag snag)
        {
            _context.Entry(snag).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var snag = GetById(id);
            _context.Snag.Remove(snag);
            _context.SaveChanges();
        }
    }
}
