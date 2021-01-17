using Microsoft.EntityFrameworkCore;
using Ribboned.Data;
using Ribboned.Models;
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

        public void Add(UserProfile up)
        {
            _context.Add(up);
            _context.SaveChanges();
        }

        public void Update(UserProfile up)
        {
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
