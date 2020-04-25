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


        /// <summary>
        /// Adds a patient to the repository.
        /// </summary>
        /// <param name="patient"> the given patient. </param>
        public void Create(Patient patient)
        {
            _laboratoryDbContext.Patients.Add(patient);
            _laboratoryDbContext.SaveChanges();
        }


        /// <summary>
        /// Gets all patients from the database.
        /// </summary>
        /// <returns> The patients. </returns>
        public IEnumerable<Patient> ReadAll()
        {
            return _laboratoryDbContext.Patients;
        }

        /// <summary>
        /// Gets a patient from the database.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The patient. </returns>
        public Patient ReadById(int id)
        {
            return _laboratoryDbContext.Patients.FirstOrDefault(c => c.Id == id);
        }


        /// <summary>
        /// Updates a patient from the database.
        /// </summary>
        /// <param name="patient"> The given patient. </param>
        public void Update(Patient patient)
        {
            _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id).FirstName = patient.FirstName;
            _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id).LastName = patient.LastName;
            _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id).City = patient.City;
            _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id).Email = patient.Email;
            _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id).Phone = patient.Phone;

            _laboratoryDbContext.SaveChanges();
        }

        /// <summary>
        /// Deletes a patient from the database.
        /// </summary>
        /// <param name="id"> The given id. </param>
        public void Delete(int id)
        {
            var _patient = _laboratoryDbContext.Patients.FirstOrDefault(p => p.Id == id);
            _laboratoryDbContext.Patients.Remove(_patient);
            _laboratoryDbContext.SaveChanges();         
        }
    }
}
