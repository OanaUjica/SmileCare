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
        private readonly IRepository _repository;

        public CaseController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Case newCase)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var _newCase = new Case
            {
                Id = newCase.Id,
                Dentist = newCase.Dentist,
                Patient = newCase.Patient,
                Employee = newCase.Employee,
                Stage = newCase.Stage,
                Category = newCase.Category,
                Tooth = newCase.Tooth,
                RestorationType = newCase.RestorationType,
                Shade = newCase.Shade,
                Comment = newCase.Comment,
                CreationDate = newCase.CreationDate,
                IsImplant = newCase.IsImplant
            };

            _repository.Create(_newCase);

            return RedirectToAction(nameof(ReadAll), _newCase);
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var _cases = _repository.ReadAll().OrderBy(c => c.Dentist);
            return View(_cases);
        }
    }
}