﻿using Microsoft.EntityFrameworkCore;
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

        public List<Ribbon> GetAll()
        {
            return _context.Ribbon.Include(r => r.Snags).Include(r => r.Category.UserProfile).ToList();
        }

        public List<Ribbon> GetByUserId(int id)
        {
            return _context.Ribbon.Include(r => r.Snags).Where(r => r.Category.UserProfileId == id).ToList();
        }

        public List<Ribbon> GetByMostRecentRibbons(int id)
        {
            var ribbons = GetByUserId(id); //only user ribbons
             return (List<Ribbon>)ribbons.SelectMany(ribbon => ribbon.Snags)
                .OrderByDescending(s => s.DateCreated)
                .GroupBy(s => s.RibbonId).Select(s => s.FirstOrDefault())
                .Take(5);
        }

        public Ribbon GetById(int id)
        {
            return _context.Ribbon
                .Include(r => r.Category.UserProfile)
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
            var local = _context.Set<Ribbon>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(ribbon.Id));
            //check if local is not null
            if (local != null)
            {
                //  detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(ribbon).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var relatedSnags = _context.Snag.Where(s => s.RibbonId == id);
            _context.Snag.RemoveRange(relatedSnags);

            var ribbon = GetById(id);
            _context.Ribbon.Remove(ribbon);
            _context.SaveChanges();
        }

        public List<Ribbon> Search(string q, int userId)
        {
            //search for ribbons by title, description or snag note

            //check for empy string
            if(string.IsNullOrWhiteSpace(q))
            {
                return new List<Ribbon>();
            }

            var queryString = q.Trim().ToLower();
            var ribbons = GetByUserId(userId); //only user ribbons
            var querySnagsArray = ribbons.Select(ribbon => ribbon.Snags).ToList();
            var foundInSnags = new List<Ribbon>();

            foreach (List<Snag> snags in querySnagsArray)
            {
                foreach(Snag snag in snags)
                {
                    if (snag.Note.ToLower().Contains(queryString))
                    {
                        foundInSnags.Add(snag.Ribbon);
                    }
                }
            }

            var query = _context.Ribbon
                                .Include(r => r.Snags)
                                .Where(r => (r.Title.ToLower().Contains(queryString) || r.Decription.ToLower().Contains(queryString)) && r.Category.UserProfileId == userId).ToList()
                                .Concat(foundInSnags)//add the ribbons found in snags
                                .Distinct() //remove all duplcates
                                .OrderByDescending(p => p.DateCreated).ToList();

            return query;

        }
    }
}
