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

        [HttpGet]
        public IActionResult ReadAll()
        {
            var _cases = _repository.ReadAll().OrderBy(c => c.Dentist);
            return View(_cases);
        }
    }
}