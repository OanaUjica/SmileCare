using SmileCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmileCare.Repository
{
    public class MockRepository : IRepository
    {
        private List<Case> _cases;


        public MockRepository()
        {
            if (_cases == null)
            {
                InitializeCases();
            }
        }

        private void InitializeCases()
        {
            _cases = new List<Case>
            {
                
                new Case {Id = 1, Dentist = "Carol Moldovan", Patient = "Ujica Remus", Stage = Stage.Received, Date = "20/04/2020", Employee = "Ujica Oana", Category = Category.Bridge, Tooth = Tooth.LowerCanine, RestorationType = RestorationType.CrownOverImplant, Shade = Shade.A35, IsImplant = true, Comment = "Please verify if we can do this case in 7 days."},
                new Case {Id = 2, Dentist = "Carol Moldovan", Patient = "Ujica Remus", Stage = Stage.Received, Date = "20/04/2020", Employee = "Ujica Oana", Category = Category.Bridge, Tooth = Tooth.LowerCanine, RestorationType = RestorationType.CrownOverImplant, Shade = Shade.A35, IsImplant = true, Comment = "Please verify if we can do this case in 7 days."},
                new Case {Id = 3, Dentist = "Carol Moldovan", Patient = "Ujica Remus", Stage = Stage.Received, Date = "20/04/2020", Employee = "Ujica Oana", Category = Category.Bridge, Tooth = Tooth.LowerCanine, RestorationType = RestorationType.CrownOverImplant, Shade = Shade.A35, IsImplant = true, Comment = "Please verify if we can do this case in 7 days."},
                new Case {Id = 4, Dentist = "Carol Moldovan", Patient = "Ujica Remus", Stage = Stage.Received, Date = "20/04/2020", Employee = "Ujica Oana", Category = Category.Bridge, Tooth = Tooth.LowerCanine, RestorationType = RestorationType.CrownOverImplant, Shade = Shade.A35, IsImplant = true, Comment = "Please verify if we can do this case in 7 days."},

            };
        }

        public void Create(Case entity)
        {

            throw new NotImplementedException();
        }

        public IEnumerable<Case> ReadAll()
        {
            return _cases;
        }

        public Case ReadById(int id)
        {
            return _cases.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Case entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
