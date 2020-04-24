﻿using SmileCare.Domain;
using System.Collections.Generic;

namespace SmileCare.Repository
{
    public interface IRepository<T> /*where T : Entity*/
    {
        void Create(T entity);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Update(T entity);
        void Delete(int id);
        //IOrderedQueryable<Patient> PopulatePatientDropDownList();
    }
}
