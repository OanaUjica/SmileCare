using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmileCare.Models;
using SmileCare.Repository;

namespace SmileCare.Controllers
{
    public class CaseController : Controller
    {
        private readonly IRepository<Case> _repository;

        public CaseController(IRepository<Case> repository)
        {
            _repository = repository;
        }





        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("DentistId,PatientId,Employee,Stage,Category,Tooth,RestorationType,Shade,Price,Comment,CreationDate,IsImplant")]Case newCase)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var _newCase = new Case
            {               
                DentistId = newCase.Dentist.Id,
                PatientId = newCase.Patient.Id,
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

            _repository.Create(_newCase);

            var _listOfCases= _repository.ReadAll().OrderBy(p => p.Id);

            return RedirectToAction(nameof(ReadAll), _listOfCases);
        }







        [HttpGet]
        public IActionResult ReadAll()
        {
            var _cases = _repository.ReadAll().OrderBy(c => c.DentistId);
            return View(_cases);
        }
    }
}