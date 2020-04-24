using SmileCare.Domain;
using SmileCare.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SmileCare.Service
{
    public class PatientService
    {
        private readonly IRepository<Patient> _repository;

        public PatientService(IRepository<Patient> repository)
        {
            _repository = repository;
        }
        

        public void Create(Patient newPatient)
        {
            // exception

            var _newPatient = new Patient
            {
                FirstName = newPatient.FirstName,
                LastName = newPatient.LastName,
                City = newPatient.City,
                Email = newPatient.Email,
                Phone = newPatient.Phone
            };

            _repository.Create(_newPatient);
        }


        public IEnumerable<Patient> ReadAll()
        {
            return _repository.ReadAll().OrderBy(d => d.Id);
        }


        public Patient ReadById(int id)
        {
            var _patient = _repository.ReadById(id);

            if (_patient == null)
            {
                return null;
            }

            return _patient;

        }


        public void Update(Patient patient)
        {
            _repository.Update(patient);
        }


        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
