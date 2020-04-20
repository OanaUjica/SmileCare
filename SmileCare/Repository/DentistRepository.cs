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
            if (_laboratoryDbContext.Dentists.FirstOrDefault(d => d.Id == dentist.Id) == null)
            {
                _laboratoryDbContext.SaveChanges();
            }
            _laboratoryDbContext.Dentists.Single(d => d.Id == dentist.Id).FirstName = dentist.FirstName;
            _laboratoryDbContext.Dentists.Single(d => d.Id == dentist.Id).LastName = dentist.LastName;
            _laboratoryDbContext.Dentists.Single(d => d.Id == dentist.Id).City = dentist.City;
            _laboratoryDbContext.Dentists.Single(d => d.Id == dentist.Id).Email = dentist.Email;
            _laboratoryDbContext.Dentists.Single(d => d.Id == dentist.Id).Phone = dentist.Phone;

            //_laboratoryDbContext.Dentists.Update(dentist);
            _laboratoryDbContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var _dentist = _laboratoryDbContext.Dentists.FirstOrDefault(p => p.Id == id);
            if (_dentist != null)
            {
                _laboratoryDbContext.Dentists.Remove(_dentist);
                _laboratoryDbContext.SaveChanges();
            }
        }

        //public IOrderedQueryable<Patient> PopulatePatientDropDownList()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
