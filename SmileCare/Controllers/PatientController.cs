using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmileCare.Models;
using SmileCare.Repository;

namespace SmileCare.Controllers
{
    public class PatientController : Controller
    {
        private readonly IRepository<Patient> _repository;

        public PatientController(IRepository<Patient> repository)
        {
            _repository = repository;
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

            var _newPatient = new Patient
            {
                FirstName = newPatient.FirstName,
                LastName = newPatient.LastName,
                City = newPatient.City,
                Email = newPatient.Email,
                Phone = newPatient.Phone
            };

            _repository.Create(_newPatient);
            
            var _listOfPatients = _repository.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfPatients);
        }






        public IActionResult ReadAll()
        {
            var _patients = _repository.ReadAll().OrderBy(d => d.Id);
            return View(_patients);
        }

    }
}