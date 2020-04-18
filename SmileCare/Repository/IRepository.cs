using SmileCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmileCare.Repository
{
    public interface IRepository
    {
        void Create(Case entity);
        IEnumerable<Case> ReadAll();
        Case ReadById(int id);
        void Update(Case entity);
        void Delete(int id);
    }
}
