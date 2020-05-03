using System.Collections.Generic;
using System.Linq;
using SmileCare.Domain;

namespace SmileCare.Repository
{
    public class DentistRepository : IRepository<Dentist>
    {

        private readonly LaboratoryDbContext _laboratoryDbContext;

        public DentistRepository(LaboratoryDbContext laboratoryDbContext)
        {
            _laboratoryDbContext = laboratoryDbContext;
        }

        /// <summary>
        /// Adds a dentist to the repository.
        /// </summary>
        /// <param name="patient"> the given dentist. </param>
        public void Create(Dentist dentist)
        {
            _laboratoryDbContext.Dentists.Add(dentist);
            _laboratoryDbContext.SaveChanges();
        }


        /// <summary>
        /// Gets all dentists from the database.
        /// </summary>
        /// <returns> The dentists. </returns>
        public List<Dentist> ReadAll()
        {
            return _laboratoryDbContext.Dentists.ToList();
        }

        /// <summary>
        /// Gets a dentist from the database.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The dentist. </returns>
        public Dentist ReadById(int id)
        {
            return _laboratoryDbContext.Dentists.FirstOrDefault(c => c.Id == id);
        }


        /// <summary>
        /// Updates a dentist from the database.
        /// </summary>
        /// <param name="dentist"> The given dentist. </param>
        public void Update(Dentist dentist)
        {
            if (_laboratoryDbContext.Dentists.FirstOrDefault(d => d.Id == dentist.Id) == null)
            {
                _laboratoryDbContext.SaveChanges();
            }
            _laboratoryDbContext.Dentists.FirstOrDefault(d => d.Id == dentist.Id).FirstName = dentist.FirstName;
            _laboratoryDbContext.Dentists.FirstOrDefault(d => d.Id == dentist.Id).LastName = dentist.LastName;
            _laboratoryDbContext.Dentists.FirstOrDefault(d => d.Id == dentist.Id).City = dentist.City;
            _laboratoryDbContext.Dentists.FirstOrDefault(d => d.Id == dentist.Id).Email = dentist.Email;
            _laboratoryDbContext.Dentists.FirstOrDefault(d => d.Id == dentist.Id).Phone = dentist.Phone;

            _laboratoryDbContext.SaveChanges();
        }

        /// <summary>
        /// Deletes a dentist from the database.
        /// </summary>
        /// <param name="id"> The given id. </param>
        public void Delete(int id)
        {
            var _dentist = _laboratoryDbContext.Dentists.FirstOrDefault(p => p.Id == id);
            if (_dentist != null)
            {
                _laboratoryDbContext.Dentists.Remove(_dentist);
                _laboratoryDbContext.SaveChanges();
            }
        }
    }
}
