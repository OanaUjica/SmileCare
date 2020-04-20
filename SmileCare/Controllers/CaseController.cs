using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmileCare.Models;
using SmileCare.Repository;

namespace SmileCare.Controllers
{
    public class CaseController : Controller
    {
        private readonly IRepository<Case> _repository;
        private readonly IRepository<Patient> _patientRepository;
        private readonly IRepository<Dentist> _dentistRepository;


        public CaseController(IRepository<Case> repository, IRepository<Patient> patientRepository, IRepository<Dentist> dentistRepository)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _dentistRepository = dentistRepository;
        }





        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_patientRepository.ReadAll(), "Id", "FullName");
            ViewData["DentistId"] = new SelectList(_dentistRepository.ReadAll(), "Id", "FullName");

            //PopulatePatientDropDownList();
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("DentistId,PatientId,Employee,Stage,Category,Tooth,RestorationType,Shade,Price,Comment,CreationDate,IsImplant")]Case newCase)
        {
            if (!ModelState.IsValid)
            {
                return View(newCase);
            }

            var _newCase = new Case
            {
                DentistId = newCase.DentistId,
                PatientId = newCase.PatientId,
                Employee = newCase.Employee,
                Stage = newCase.Stage,
                Category = newCase.Category,
                Tooth = newCase.Tooth,
                RestorationType = newCase.RestorationType,
                Shade = newCase.Shade,
                Price = newCase.Price,
                Comment = newCase.Comment,
                CreationDate = newCase.CreationDate,
                IsImplant = newCase.IsImplant
            };

            _repository.Create(newCase);

            var _listOfCases= _repository.ReadAll().OrderBy(c => c.DentistId);

            return RedirectToAction(nameof(ReadAll), _listOfCases);
        }

        //private void PopulatePatientDropDownList(string selectedPatient = null)
        //{
        //    var patientQuery = _repository.PopulatePatientDropDownList();
        //    ViewBag.PatientId = new SelectList(patientQuery.AsNoTracking(), "FullName", selectedPatient);
        //}







        [HttpGet]
        public IActionResult ReadAll()
        {
            var _cases = _repository.ReadAll().OrderBy(c => c.DentistId);
            return View(_cases);
        }


        [HttpGet]
        public IActionResult ReadById(int id)
        {
            var _case = _repository.ReadById(id);

            if (_case == null)
            {
                return NotFound();
            }

            return View(_case);
        }








        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var _case = _repository.ReadById(id);
                return View(_case);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Update(Case updatedCase)
        {
            _repository.Update(updatedCase);

            var _listOfCases = _repository.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfCases);
        }







                            
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var _case = _repository.ReadById(id);
                return View(_case);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }


        [HttpPost]
        public IActionResult PostDelete(int id)
        {
            _repository.Delete(id);

            var _listOfCases = _repository.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfCases);
        }
    }
}