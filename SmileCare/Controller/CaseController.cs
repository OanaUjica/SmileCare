using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmileCare.Domain;
using SmileCare.Repository;
using SmileCare.Service;

namespace SmileCare.Controllers
{
    public class CaseController : Controller
    {
        private readonly CaseService _caseService;
        private readonly PatientService _patientService;
        private readonly DentistService _dentistService;


        public CaseController(CaseService caseService, PatientService patientService, DentistService dentistService)
        {
            _caseService = caseService;
            _patientService = patientService;
            _dentistService = dentistService;
        }





        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_patientService.ReadAll(), "Id", "FullName");
            ViewData["DentistId"] = new SelectList(_dentistService.ReadAll(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("DentistId,PatientId,Employee,Stage,Category,Tooth,RestorationType,Shade,Price,Comment,CreationDate,IsImplant")]Case newCase)
        {
            if (!ModelState.IsValid)
            {
                ViewData["PatientId"] = new SelectList(_patientService.ReadAll(), "Id", "FullName");
                ViewData["DentistId"] = new SelectList(_dentistService.ReadAll(), "Id", "FullName");
                return View(newCase);
            }

            _caseService.Create(newCase);

            var _listOfCases= _caseService.ReadAll().OrderBy(c => c.DentistId);

            return RedirectToAction(nameof(ReadAll), _listOfCases);
        }








        [HttpGet]
        public IActionResult ReadAll()
        {
            var _cases = _caseService.ReadAll().OrderBy(c => c.Id);
            return View(_cases);
        }


        [HttpGet]
        public IActionResult ReadById(int id)
        {
            var _case = _caseService.ReadById(id);

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
                var _case = _caseService.ReadById(id);
                ViewData["PatientId"] = new SelectList(_patientService.ReadAll(), "Id", "FullName", _case.PatientId);
                ViewData["DentistId"] = new SelectList(_dentistService.ReadAll(), "Id", "FullName", _case.DentistId);
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
            if (!ModelState.IsValid)
            {
                ViewData["PatientId"] = new SelectList(_patientService.ReadAll(), "Id", "FullName");
                ViewData["DentistId"] = new SelectList(_dentistService.ReadAll(), "Id", "FullName");
                return View(updatedCase);
            }

            _caseService.Update(updatedCase);

            var _listOfCases = _caseService.ReadAll().OrderBy(c => c.DentistId);

            ViewData["PatientId"] = new SelectList(_patientService.ReadAll(), "Id", "FullName", updatedCase.PatientId);
            ViewData["DentistId"] = new SelectList(_dentistService.ReadAll(), "Id", "FullName", updatedCase.DentistId);
            return RedirectToAction(nameof(ReadAll), _listOfCases);
        }







                            
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var _case = _caseService.ReadById(id);
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
            _caseService.Delete(id);

            var _listOfCases = _caseService.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfCases);
        }

        [HttpGet]
        public IActionResult GetBillsPerCases()
        {
            var _bills = _caseService.GetBillPerCase();

            return View(_bills);
        }
    }
}