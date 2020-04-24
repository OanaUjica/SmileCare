using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmileCare.Domain;
using SmileCare.Repository;
using SmileCare.Service;

namespace SmileCare.Controllers
{
    public class PatientController : Controller
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }




        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("FirstName,LastName,City,Email,Phone")]Patient newPatient)
        {
            if (!ModelState.IsValid)
            {
                return View(newPatient);
            }

            _patientService.Create(newPatient);
            
            var _listOfPatients = _patientService.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfPatients);
        }







        [HttpGet]
        public IActionResult ReadAll()
        {
            var _patients = _patientService.ReadAll().OrderBy(d => d.Id);
            return View(_patients);
        }


        [HttpGet]
        public IActionResult ReadById(int id)
        {
            var _patient = _patientService.ReadById(id);

            if (_patient == null)
            {
                return NotFound();
            }

            return View(_patient);
        }







        [HttpGet]
        public IActionResult Update(int id)
        {
            var _patient = _patientService.ReadById(id);
            if (_patient == null)
            {
                return NotFound();
            }
            return View(_patient);                    
        }

        [HttpPost]
        public IActionResult Update(Patient patient)
        {
            var _patient = _patientService.ReadById(patient.Id);
            if (_patient == null)
            {
                return NotFound();
            }
            _patientService.Update(patient);

            var _listOfPatients = _patientService.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfPatients);
        }







        [HttpGet]
        public IActionResult Delete(int id)
        {
            var _patient = _patientService.ReadById(id);
            if (_patient == null)
            {
                return NotFound();
            }
            return View(_patient);
        }

        [HttpPost]
        public IActionResult PostDelete(int id)
        {
            var _patient = _patientService.ReadById(id);
            if (_patient == null)
            {
                return NotFound();
            }
            _patientService.Delete(id);

            var _listOfPatients = _patientService.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfPatients);
        }
    }
}