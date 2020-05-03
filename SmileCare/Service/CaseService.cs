
using SmileCare.Domain;
using SmileCare.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SmileCare.Service
{
    public class CaseService
    {
        private readonly IRepository<Case> _repository;

        public CaseService(IRepository<Case> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds a case to the repository.
        /// </summary>
        /// <param name="newCase"> The given new case. </param>
        public void Create(Case newCase)
        {
            var _newCase = new Case
            {
                DentistId = newCase.DentistId,
                PatientId = newCase.PatientId,
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
        }

        /// <summary>
        /// Gets all the cases from the repository.
        /// </summary>
        /// <returns> The cases. </returns>
        public List<Case> ReadAll()
        {
            return _repository.ReadAll().OrderByDescending(c => c.CreationDate).ToList();
        }

        /// <summary>
        /// Gets the case from the repository that matches a given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        /// <returns> The case. </returns>
        public Case ReadById(int id)
        {
            var _case = _repository.ReadById(id);

            if (_case == null)
            {
                return null;
            }

            return _case;

        }

        /// <summary>
        /// Updates the given case from the repository.
        /// </summary>
        /// <param name="_case"> The given case. </param>
        public void Update(Case _case)
        {
            _repository.Update(_case);
        }

        /// <summary>
        /// Deletes the case that matches a given id.
        /// </summary>
        /// <param name="id"> The given id. </param>
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        /// <summary>
        /// Get the bills from repository.
        /// </summary>
        /// <returns> The list of bills. </returns>
        public List<BillViewModel> GetBillPerCase()
        {
            var bills = new List<BillViewModel>();

            foreach (var _case in _repository.ReadAll().OrderByDescending(c => c.CreationDate))
            {
                bills.Add(new BillViewModel { DentistName = _case.Dentist.FullName, PatientName = _case.Patient.FullName, Price = _case.Price, RestorationType = _case.RestorationType });
            }

            return bills;
        }
    }
}
