using Ribboned.Models;
using System.Collections.Generic;

namespace Ribboned.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        List<Category> GetByUserId(int userId);
        void Delete(int id, int userId);
        void Update(Category category);
        void Add(Category category);
        Category GetById(int id);
    }
}