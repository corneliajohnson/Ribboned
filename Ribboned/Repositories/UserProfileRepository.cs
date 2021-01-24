using Microsoft.EntityFrameworkCore;
using Ribboned.Data;
using Ribboned.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ribboned.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserProfile GetByFirebaseUserId(string firebaseUserId)
        {
            return _context.UserProfile
                .FirstOrDefault(up => up.FirebaseUserId == firebaseUserId);

        }

        public List<UserProfile> GetAll()
        {
            return _context.UserProfile.ToList();
        }

        public void Add(UserProfile up)
        {
            _context.Add(up);
            _context.SaveChanges();
        }

        public void Update(UserProfile up)
        {
            var local = _context.Set<UserProfile>()
              .Local
                .FirstOrDefault(entry => entry.Id.Equals(up.Id));
            //check if local is not null
            if (local != null)
            {
                //  detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(up).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public UserProfile GetByFireBaseId(string firebaseUserId)
        {
            return _context.UserProfile
        .FirstOrDefault(up => up.FirebaseUserId == firebaseUserId);
        }

        public UserProfile GetById(int id)
        {
            return _context.UserProfile
        .FirstOrDefault(up => up.Id == id);
        }
    }
}
