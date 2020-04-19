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
            throw new NotImplementedException();
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
