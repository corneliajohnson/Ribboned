using Microsoft.EntityFrameworkCore;
using Ribboned.Data;
using Ribboned.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ribboned.Repositories
{
    public class RibbonRepository : IRibbonRepository
    {
        private readonly ApplicationDbContext _context;

        public RibbonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Ribbon> GetByUserId(int id)
        {
            return _context.Ribbon.Where(r => r.UserProfileId == id).ToList();
        }

        public Ribbon GetById(int id)
        {
            return _context.Ribbon.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Ribbon ribbon)
        {
            _context.Add(ribbon);
            _context.SaveChanges();
        }

        public void Update(Ribbon ribbon)
        {
            _context.Entry(ribbon).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ribbon = GetById(id);
            _context.Ribbon.Remove(ribbon);
            _context.SaveChanges();
        }
    }
}
