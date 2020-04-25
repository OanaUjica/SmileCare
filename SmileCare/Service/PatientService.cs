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

        /// <summary>
        /// Adds a patient to the repository.
        /// </summary>
        /// <param name="newPatient"> The given new patient. </param>
        public void Create(Patient newPatient)
        {
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

        /// <summary>
        /// Gets all the patients from the repository.
        /// </summary>
        /// <returns> The patients. </returns>
        public IEnumerable<Patient> ReadAll()
        {
            return _repository.ReadAll().OrderBy(d => d.Id);
        }

        /// <summary>
        /// Gets the patient from the repository that matches a given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The patient. </returns>
        public Patient ReadById(int id)
        {
            var _patient = _repository.ReadById(id);

            if (_patient == null)
            {
                return null;
            }

            return _patient;

        }

        /// <summary>
        /// Updates the given patient from the repository.
        /// </summary>
        /// <param name="patient"> The given patient. </param>
        public void Update(Patient patient)
        {
            _repository.Update(patient);
        }

        /// <summary>
        /// Deletes the patient that matches a given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
