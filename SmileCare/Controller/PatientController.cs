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



        /// <summary>
        /// The EndPoint maps to this action method to create a new patient.
        /// </summary>
        /// <returns> The View page. </returns>
        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }

        /// <summary>
        /// Creates a new patient.
        /// </summary>
        /// <param name="newPatient"> The given patient. </param>
        /// <returns> All the patients from Service to the View page. </returns>
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

        /// <summary>
        /// Gets all the patients from Service.
        /// </summary>
        /// <returns> The patients to View page. </returns>
        [HttpGet]
        public IActionResult ReadAll()
        {
            var _patients = _patientService.ReadAll().OrderBy(d => d.Id);
            return View(_patients);
        }

        /// <summary>
        /// Gets the patient with a given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The patient to View page. </returns>
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


        /// <summary>
        /// Gets from View the id of a patient to be updated.
        /// </summary>
        /// <param name="id"> the given id. </param>
        /// <returns> To View the patient with matching id. </returns>
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

        /// <summary>
        /// Updates the given patient.
        /// </summary>
        /// <param name="patient"> The given patient. </param>
        /// <returns> The updated list of patients to View. </returns>
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

        /// <summary>
        /// Gets the patient with given id to delete it.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The patient in View. </returns> 
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

        /// <summary>
        /// Deletes the patient with given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The View with all the remaining patients. </returns>
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