using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmileCare.Domain;
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


        /// <summary>
        /// The EndPoint maps to this action method to create a new case.
        /// </summary>
        /// <returns> The View page. </returns>
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_patientService.ReadAll(), "Id", "FullName");
            ViewData["DentistId"] = new SelectList(_dentistService.ReadAll(), "Id", "FullName");
            return View();
        }

        /// <summary>
        /// Creates the new case.
        /// </summary>
        /// <param name="newCase"> The given case. </param>
        /// <returns> All the cases from Service to the View page. </returns>
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

            var _listOfCases= _caseService.ReadAll().OrderByDescending(c => c.CreationDate);

            return RedirectToAction(nameof(ReadAll), _listOfCases);
        }

        /// <summary>
        /// Gets all the cases from Service.
        /// </summary>
        /// <returns> The cases to View page. </returns>
        [HttpGet]
        public IActionResult ReadAll()
        {
            var _cases = _caseService.ReadAll().OrderByDescending(c => c.CreationDate);
            return View(_cases);
        }

        /// <summary>
        /// Gets the case with a given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The case to View page. </returns>
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

        /// <summary>
        /// Gets from View the id of a case to update it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> To View the case with matching id. </returns>
        [HttpGet]
        public IActionResult Update(int id)
        {
            var _case = _caseService.ReadById(id);

            if (_case == null)
            {
                return NotFound();
            }

            ViewData["PatientId"] = new SelectList(_patientService.ReadAll(), "Id", "FullName", _case.PatientId);
            ViewData["DentistId"] = new SelectList(_dentistService.ReadAll(), "Id", "FullName", _case.DentistId);
            return View(_case);
        }

        /// <summary>
        /// Updates the given case.
        /// </summary>
        /// <param name="updatedCase"> The given case. </param>
        /// <returns> The updated list of cases to View. </returns>
        [HttpPost]
        public IActionResult Update(Case updatedCase)
        {
            if (!ModelState.IsValid)
            {
                ViewData["PatientId"] = new SelectList(_patientService.ReadAll(), "Id", "FullName");
                ViewData["DentistId"] = new SelectList(_dentistService.ReadAll(), "Id", "FullName");
                return View(updatedCase);
            }

            var _case = _caseService.ReadById(updatedCase.Id);

            if (_case == null)
            {
                return NotFound();
            }

            _caseService.Update(updatedCase);

            var _listOfCases = _caseService.ReadAll().OrderByDescending(c => c.CreationDate);

            ViewData["PatientId"] = new SelectList(_patientService.ReadAll(), "Id", "FullName", _case.PatientId);
            ViewData["DentistId"] = new SelectList(_dentistService.ReadAll(), "Id", "FullName", _case.DentistId);
            return RedirectToAction(nameof(ReadAll), _listOfCases);
        }

        /// <summary>
        /// Gets the case with given id to delete it.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The case in View. </returns>        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var _case = _caseService.ReadById(id);

            if (_case == null)
            {
                return NotFound();
            }

            return View(_case);
        }

        /// <summary>
        /// Deletes the case with given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The View with all the remaining cases. </returns>
        [HttpPost]
        public IActionResult PostDelete(int id)
        {
            var _case = _caseService.ReadById(id);

            if (_case == null)
            {
                return NotFound();
            }

            _caseService.Delete(id);

            var _listOfCases = _caseService.ReadAll().OrderByDescending(c => c.CreationDate);

            return RedirectToAction(nameof(ReadAll), _listOfCases);
        }

        /// <summary>
        /// Gets the list of BillViewModel from Service.
        /// </summary>
        /// <returns> The list of bills to View. </returns>
        [HttpGet]
        public IActionResult GetBillsPerCases()
        {
            var _bills = _caseService.GetBillPerCase();

            return View(_bills);
        }
    }
}