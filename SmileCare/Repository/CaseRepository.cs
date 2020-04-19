﻿using Microsoft.EntityFrameworkCore;
using SmileCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmileCare.Repository
{
    public class CaseRepository : IRepository<Case>
    {
        private readonly LaboratoryDbContext _laboratoryDbContext;

        public CaseRepository(LaboratoryDbContext laboratoryDbContext)
        {
            _laboratoryDbContext = laboratoryDbContext;
        }

        public void Create(Case entity)
        {
            _laboratoryDbContext.Cases.Add(entity);
            _laboratoryDbContext.SaveChanges();
        }



        public IEnumerable<Case> ReadAll()
        {
            return _laboratoryDbContext.Cases;
        }



        public Case ReadById(int id)
        {
            return _laboratoryDbContext.Cases.FirstOrDefault(c => c.Id == id);
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
