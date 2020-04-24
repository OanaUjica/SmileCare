using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmileCare.Domain;
using SmileCare.Service;

namespace SmileCare.Controllers
{
    public class DentistController : Controller
    {

        private readonly DentistService _dentistService;

        public DentistController(DentistService dentistService)
        {
            _dentistService = dentistService;
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

            _dentistService.Create(newDentist);

            var _listOfDentists = _dentistService.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfDentists);
        }



        [HttpGet]
        public IActionResult ReadAll()
        {
            var _dentists = _dentistService.ReadAll().OrderBy(d => d.Id);
            return View(_dentists);
        }


        [HttpGet]
        public IActionResult ReadById(int id)
        {
            var _dentist = _dentistService.ReadById(id);

            if (_dentist == null)
            {
                return NotFound();
            }

            return View(_dentist);
        }







        [HttpGet]
        public IActionResult Update(int id)
        {
            var _dentist = _dentistService.ReadById(id);

            if (_dentist == null)
            {
                return NotFound();
            }

            return View(_dentist);
        }

        [HttpPost]
        public IActionResult Update(Dentist dentist)
        {
            var _dentist = _dentistService.ReadById(dentist.Id);

            if (_dentist == null)
            {
                return NotFound();
            }

            _dentistService.Update(dentist);

            var _listOfDentists = _dentistService.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfDentists);
        }










        [HttpGet]
        public IActionResult Delete(int id)
        {
            var _dentist = _dentistService.ReadById(id);

            if (_dentist == null)
            {
                return NotFound();
            }

            return View(_dentist);
        }

        [HttpPost]
        public IActionResult PostDelete(int id)
        {
            var _dentist = _dentistService.ReadById(id);

            if (_dentist == null)
            {
                return NotFound();
            }

            _dentistService.Delete(id);

            var _listOfDentists = _dentistService.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfDentists);
        }

    }
}