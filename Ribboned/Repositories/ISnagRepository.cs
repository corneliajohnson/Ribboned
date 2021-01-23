using Ribboned.Models;
using System.Collections.Generic;

namespace Ribboned.Repositories
{
    public interface ISnagRepository
    {
        void Add(Snag snag);
        void Delete(int id);
        Snag GetById(int id);
        List<Snag> GetByRibbon(int ribbonId);
        void Update(Snag snag);
    }
}