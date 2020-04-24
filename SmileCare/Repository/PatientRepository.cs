using SmileCare.Domain;
using System.Collections.Generic;
using System.Linq;

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
            // exception
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
            // exception
            _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id).FirstName = patient.FirstName;
            _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id).LastName = patient.LastName;
            _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id).City = patient.City;
            _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id).Email = patient.Email;
            _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id).Phone = patient.Phone;

            //_laboratoryDbContext.Patients.Update(patient);
            _laboratoryDbContext.SaveChanges();
        }


        public void Delete(int id)
        {
            // exception
            var _patient = _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == id);
            _laboratoryDbContext.Patients.Remove(_patient);
            _laboratoryDbContext.SaveChanges();         
        }

    }
}
