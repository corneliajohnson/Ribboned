using Ribboned.Models;
using System.Collections.Generic;

namespace Ribboned.Repositories
{
    public interface IRibbonRepository1
    {
        void Add(Ribbon ribbon);
        void Delete(int id);
        Ribbon GetById(int id);
        List<Ribbon> GetByUserId(int id);
        void Update(Ribbon ribbon);
    }
}