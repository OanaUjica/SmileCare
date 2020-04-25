using SmileCare.Domain;
using SmileCare.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SmileCare.Service
{
    public class DentistService
    {
        private readonly IRepository<Dentist> _repository;

        public DentistService(IRepository<Dentist> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds a dentist to the repository.
        /// </summary>
        /// <param name="newDentist"> The given new dentist. </param>
        public void Create(Dentist newDentist)
        {
            var _newDentist = new Dentist
            {
                FirstName = newDentist.FirstName,
                LastName = newDentist.LastName,
                City = newDentist.City,
                Email = newDentist.Email,
                Phone = newDentist.Phone
            };

            _repository.Create(_newDentist);
        }

        /// <summary>
        /// Gets all the dentists from the repository.
        /// </summary>
        /// <returns> The dentists. </returns>
        public IEnumerable<Dentist> ReadAll()
        {
            return _repository.ReadAll().OrderBy(d => d.Id);
        }

        /// <summary>
        /// Gets the dentist from the repository that matches a given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The dentist. </returns>
        public Dentist ReadById(int id)
        {
            var _dentist = _repository.ReadById(id);

            if (_dentist == null)
            {
                return null;
            }

            return _dentist;

        }

        /// <summary>
        /// Updates the given dentist from the repository.
        /// </summary>
        /// <param name="dentist"> The given dentist. </param>
        public void Update(Dentist dentist)
        {
            _repository.Update(dentist);
        }

        /// <summary>
        /// Deletes the dentist that matches a given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
