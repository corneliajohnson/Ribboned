﻿using Microsoft.EntityFrameworkCore;
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
        public List<Category> GetByUserId(int userId)
        {
            return _context.Category.Include(c => c.UserProfile)
                .Where(c => c.UserProfileId == userId).ToList();
        }
        
        public Category GetById(int id)
        {
            return _context.Category.Include(c => c.UserProfile)
                .FirstOrDefault(c => c.Id == id);
        }

        public void Add(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            var local = _context.Set<Category>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(category.Id));
            //check if local is not null
            if (local != null)
            {
                //  detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            _context.Category.Remove(category);
            _context.SaveChanges();
        }

    }
}
