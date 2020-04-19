using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmileCare.Models;
using SmileCare.Repository;

namespace SmileCare.Controllers
{
    public class DentistController : Controller
    {

        private readonly IRepository<Dentist> _repository;

        public DentistController(IRepository<Dentist> repository)
        {
            _repository = repository;
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FirstName,LastName,City,Email,Phone")]Dentist newDentist)
        {
            if (!ModelState.IsValid)
            {
                return View(newDentist);
            }

            var _newDentist = new Dentist
            {
                FirstName = newDentist.FirstName,
                LastName = newDentist.LastName,
                City = newDentist.City,
                Email = newDentist.Email,
                Phone = newDentist.Phone
            };

            _repository.Create(_newDentist);

            var _listOfDentists = _repository.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfDentists);
        }




        public IActionResult ReadAll()
        {
            var _dentists = _repository.ReadAll().OrderBy(d => d.Id);
            return View(_dentists);
        }
    }
}