using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmileCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .Include(p => p.Patient)
                .AsNoTracking()
                .Include(d => d.Dentist)
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
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).DentistId = entity.DentistId;
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).PatientId = entity.PatientId;
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).Employee = entity.Employee;
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).Stage = entity.Stage;
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).Category = entity.Category;
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).Tooth = entity.Tooth;
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).RestorationType = entity.RestorationType;
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).Shade = entity.Shade;
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).Comment = entity.Comment;
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).Price = entity.Price;
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).CreationDate = entity.CreationDate;
            _laboratoryDbContext.Cases.Single(d => d.Id == entity.Id).IsImplant = entity.IsImplant;


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
