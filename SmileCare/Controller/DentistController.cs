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



        /// <summary>
        /// The EndPoint maps to this action method to create a new dentist.
        /// </summary>
        /// <returns> The View page. </returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the new dentist.
        /// </summary>
        /// <param name="newDentist"> The given dentist. </param>
        /// <returns> All the dentist from Service to the View page. </returns>
        [HttpPost]
        public IActionResult Create([Bind("FirstName,LastName,City,Email,Phone")]Dentist newDentist)
        {
            if (!ModelState.IsValid)
            {
                return View(newDentist);
            }

            _dentistService.Create(newDentist);

            var _listOfDentists = _dentistService.ReadAll().OrderBy(p => p.Id).ToList();

            return RedirectToAction(nameof(ReadAll), _listOfDentists);
        }


        /// <summary>
        /// Gets all the dentists from Service.
        /// </summary>
        /// <returns> The dentists to View page. </returns>
        [HttpGet]
        public IActionResult ReadAll()
        {
            var _dentists = _dentistService.ReadAll().OrderBy(d => d.Id).ToList();
            return View(_dentists);
        }

        /// <summary>
        /// Gets the dentist with a given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The dentist to View page. </returns>
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

        /// <summary>
        /// Gets from View the id of a dentist to update it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> To View the dentist with matching id. </returns>
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

        /// <summary>
        /// Updates the given dentist.
        /// </summary>
        /// <param name="dentist"> The given dentist. </param>
        /// <returns> The updated list of dentists to View. </returns>
        [HttpPost]
        public IActionResult Update(Dentist dentist)
        {
            var _dentist = _dentistService.ReadById(dentist.Id);

            if (_dentist == null)
            {
                return NotFound();
            }

            _dentistService.Update(dentist);

            var _listOfDentists = _dentistService.ReadAll().OrderBy(p => p.Id).ToList();

            return RedirectToAction(nameof(ReadAll), _listOfDentists);
        }

        /// <summary>
        /// Gets the dentist with given id to delete it.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The dentist in View. </returns> 
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

        /// <summary>
        /// Deletes the dentist with given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The View with all the remaining dentists. </returns>
        [HttpPost]
        public IActionResult PostDelete(int id)
        {
            var _dentist = _dentistService.ReadById(id);

            if (_dentist == null)
            {
                return NotFound();
            }

            _dentistService.Delete(id);

            var _listOfDentists = _dentistService.ReadAll().OrderBy(p => p.Id).ToList();

            return RedirectToAction(nameof(ReadAll), _listOfDentists);
        }

    }
}