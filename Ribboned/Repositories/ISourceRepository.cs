using Ribboned.Models;
using System.Collections.Generic;

namespace Ribboned.Repositories
{
    public interface ISourceRepository
    {
        List<Source> GetAll();
    }
}