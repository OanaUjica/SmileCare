using SmileCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmileCare.Repository
{
    public class CaseRepository : IRepository
    {
        private readonly LaboratoryDbContext _appDbContext;

        public CaseRepository(LaboratoryDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Case entity)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<Case> ReadAll()
        {
            return _appDbContext.Cases;
        }



        public Case ReadById(int id)
        {
            return _appDbContext.Cases.FirstOrDefault(c => c.Id == id);
        }



        public void Update(Case entity)
        {
            throw new NotImplementedException();
        }



        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
