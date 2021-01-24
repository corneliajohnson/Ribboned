using Ribboned.Models;

namespace Ribboned.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile up);
        UserProfile GetByFireBaseId(string firebaseUserId);
        UserProfile GetById(int id);
        void Update(UserProfile up);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
    }
}