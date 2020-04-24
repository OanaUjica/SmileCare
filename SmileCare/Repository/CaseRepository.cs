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

        public void Create(Case entity)
        {
            _laboratoryDbContext.Cases.Add(entity);
            _laboratoryDbContext.SaveChanges();
        }



        public IEnumerable<Case> ReadAll()
        {
            var _cases = _laboratoryDbContext.Cases
                .Include(d => d.Dentist)
                .AsNoTracking()
                .Include(p => p.Patient)
                .AsNoTracking();


            return _cases;
        }



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


            //_laboratoryDbContext.Cases.Update(entity);
            _laboratoryDbContext.SaveChanges();
        }



        public void Delete(int id)
        {
            var _case = _laboratoryDbContext.Cases.FirstOrDefault(p => p.Id == id);
            if (_case != null)
            {
                _laboratoryDbContext.Cases.Remove(_case);
                _laboratoryDbContext.SaveChanges();
            }
        }





        //public IOrderedQueryable<Patient> PopulatePatientDropDownList(string selectedPatient = null)
        //{
        //    var patientQuery = from p in _laboratoryDbContext.Patients
        //                       orderby p.FullName
        //                       select p;
        //    return patientQuery;
        //    //ViewBag.PatientId = new SelectList(patientQuery.AsNoTracking(), "FullName", selectedPatient);
        //}

        //public IOrderedQueryable<Patient> PopulatePatientDropDownList()
        //{
        //    var patientQuery = from p in _laboratoryDbContext.Patients
        //                       orderby p.FullName
        //                       select p;
        //    return patientQuery;
        //}
    }
}
