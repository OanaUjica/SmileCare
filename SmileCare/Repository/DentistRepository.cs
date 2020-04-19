using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmileCare.Models;

namespace SmileCare.Repository
{
    public class DentistRepository : IRepository<Dentist>
    {

        private readonly LaboratoryDbContext _laboratoryDbContext;

        public DentistRepository(LaboratoryDbContext laboratoryDbContext)
        {
            _laboratoryDbContext = laboratoryDbContext;
        }

        public void Create(Dentist dentist)
        {
            _laboratoryDbContext.Dentists.Add(dentist);
            _laboratoryDbContext.SaveChanges();
        }



        public IEnumerable<Dentist> ReadAll()
        {
            return _laboratoryDbContext.Dentists;
        }


        public Dentist ReadById(int id)
        {
            return _laboratoryDbContext.Dentists.FirstOrDefault(c => c.Id == id);
        }



        public void Update(Dentist dentist)
        {
            throw new NotImplementedException();
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
