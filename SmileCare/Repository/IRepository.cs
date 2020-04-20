using SmileCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmileCare.Repository
{
    public interface IRepository<T>
    {
        void Create(T entity);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Update(T entity);
        void Delete(int id);
        //IOrderedQueryable<Patient> PopulatePatientDropDownList();
    }
}
