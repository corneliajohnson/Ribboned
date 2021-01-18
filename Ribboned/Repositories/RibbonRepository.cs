﻿using Microsoft.EntityFrameworkCore;
using Ribboned.Data;
using Ribboned.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ribboned.Repositories
{
    public class RibbonRepository : IRibbonRepository, IRibbonRepository1
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
            return _context.Ribbon
                .Include(r => r.UserProfile)
                .Include(r => r.Snags)
                .FirstOrDefault(r => r.Id == id);
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
            var ribonToDelete = _context.Ribbon
                .Where(r => r.Id == id) //Find the ribbon by id
                .Include(r => r.Snags); //all snags connectes to Ribbon
            _context.Ribbon.RemoveRange(ribonToDelete);
            _context.SaveChanges();
        }
    }
}