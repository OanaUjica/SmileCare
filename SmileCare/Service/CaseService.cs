
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


        public void Create(Case newCase)
        {
            // exception

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


        public IEnumerable<Case> ReadAll()
        {
            return _repository.ReadAll().OrderBy(d => d.Id);
        }


        public Case ReadById(int id)
        {
            var _dentist = _repository.ReadById(id);

            if (_dentist == null)
            {
                return null;
            }

            return _dentist;

        }


        public void Update(Case dentist)
        {
            _repository.Update(dentist);
        }


        public void Delete(int id)
        {
            _repository.Delete(id);
        }


        public List<BillViewModel> GetBillPerCase()
        {
            var bills = new List<BillViewModel>();

            foreach (var _case in _repository.ReadAll())
            {
                bills.Add(new BillViewModel { DentistName = _case.Dentist.FullName, PatientName = _case.Patient.FullName, Price = _case.Price, RestorationType = _case.RestorationType });
            }

            return bills;
        }
    }
}
