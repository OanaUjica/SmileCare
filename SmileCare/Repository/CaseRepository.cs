using Microsoft.EntityFrameworkCore;
using SmileCare.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SmileCare.Repository
{
    public class CaseRepository : IRepository<Case>
    {
        private readonly LaboratoryDbContext _laboratoryDbContext;

        public CaseRepository(LaboratoryDbContext laboratoryDbContext)
        {
            _laboratoryDbContext = laboratoryDbContext;
        }

        /// <summary>
        /// Adds a case to the repository.
        /// </summary>
        /// <param name="_case"> the given case. </param>
        public void Create(Case _case)
        {
            _laboratoryDbContext.Cases.Add(_case);
            _laboratoryDbContext.SaveChanges();
        }


        /// <summary>
        /// Gets all cases from the database.
        /// </summary>
        /// <returns> The cases. </returns>
        public List<Case> ReadAll()
        {
            var _cases = _laboratoryDbContext.Cases
                .Include(d => d.Dentist)
                .AsNoTracking()
                .Include(p => p.Patient)
                .AsNoTracking();


            return _cases.ToList();
        }


        /// <summary>
        /// Gets a case from the database.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The case. </returns>
        public Case ReadById(int id)
        {
            var _case = _laboratoryDbContext.Cases
                .Include(p => p.Patient)
                .AsNoTracking()
                .Include(d => d.Dentist)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
            return _case;
        }


        /// <summary>
        /// Updates a case from the database.
        /// </summary>
        /// <param name="entity"> The given case. </param>
        public void Update(Case entity)
        {
            if (_laboratoryDbContext.Cases.FirstOrDefault(d => d.Id == entity.Id) == null)
            {
                _laboratoryDbContext.SaveChanges();
            }

            var _case = _laboratoryDbContext.Cases
                .Include(d => d.Dentist)
                .AsNoTracking()
                .Include(p => p.Patient)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == entity.Id);

            _case.DentistId = entity.DentistId;
            _case.PatientId = entity.PatientId;
            _case.Employee = entity.Employee;
            _case.Stage = entity.Stage;
            _case.Category = entity.Category;
            _case.Tooth = entity.Tooth;
            _case.RestorationType = entity.RestorationType;
            _case.Shade = entity.Shade;
            _case.Comment = entity.Comment;
            _case.Price = entity.Price;
            _case.CreationDate = entity.CreationDate;
            _case.IsImplant = entity.IsImplant;

            _laboratoryDbContext.SaveChanges();
        }


        /// <summary>
        /// Deletes a case from the database.
        /// </summary>
        /// <param name="id"> The given id. </param>
        public void Delete(int id)
        {
            var _case = _laboratoryDbContext.Cases.FirstOrDefault(p => p.Id == id);
            if (_case != null)
            {
                _laboratoryDbContext.Cases.Remove(_case);
                _laboratoryDbContext.SaveChanges();
            }
        }
    }
}
