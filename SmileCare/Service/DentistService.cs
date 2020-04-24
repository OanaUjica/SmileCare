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


        public void Create(Dentist newDentist)
        {
            // exception

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


        public IEnumerable<Dentist> ReadAll()
        {
            return _repository.ReadAll().OrderBy(d => d.Id);
        }


        public Dentist ReadById(int id)
        {
            var _dentist = _repository.ReadById(id);

            if (_dentist == null)
            {
                return null;
            }

            return _dentist;

        }


        public void Update(Dentist dentist)
        {
            _repository.Update(dentist);
        }


        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
