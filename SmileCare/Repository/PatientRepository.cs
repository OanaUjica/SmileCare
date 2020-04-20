using SmileCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmileCare.Repository
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly LaboratoryDbContext _laboratoryDbContext;

        public PatientRepository(LaboratoryDbContext laboratoryDbContext)
        {
            _laboratoryDbContext = laboratoryDbContext;
        }

        public void Create(Patient patient)
        {
            _laboratoryDbContext.Patients.Add(patient);
            _laboratoryDbContext.SaveChanges();
        }



        public IEnumerable<Patient> ReadAll()
        {
            return _laboratoryDbContext.Patients;
        }


        public Patient ReadById(int id)
        {
            return _laboratoryDbContext.Patients.FirstOrDefault(c => c.Id == id);
        }



        public void Update(Patient patient)
        {
            if (_laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id) == null)
            {
                _laboratoryDbContext.SaveChanges();
            }
            _laboratoryDbContext.Patients.Single(p => p.Id == patient.Id).FirstName = patient.FirstName;
            _laboratoryDbContext.Patients.Single(p => p.Id == patient.Id).LastName = patient.LastName;
            _laboratoryDbContext.Patients.Single(p => p.Id == patient.Id).City = patient.City;
            _laboratoryDbContext.Patients.Single(p => p.Id == patient.Id).Email = patient.Email;
            _laboratoryDbContext.Patients.Single(p => p.Id == patient.Id).Phone = patient.Phone;

            //_laboratoryDbContext.Patients.Update(patient);
            _laboratoryDbContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var _patient = _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == id);
            if (_patient != null)
            {
                _laboratoryDbContext.Patients.Remove(_patient);
                _laboratoryDbContext.SaveChanges();
            }            
        }

        //public IOrderedQueryable<Patient> PopulatePatientDropDownList()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
