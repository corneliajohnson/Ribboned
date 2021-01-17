using Ribboned.Models;
using System.Collections.Generic;

namespace Ribboned.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
    }
}