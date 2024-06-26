﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenaricRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext storeContext;

        public GenaricRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await storeContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public Task<T?> GetAsync(int id)
        {
            return storeContext.Set<T>().FirstOrDefaultAsync(entity=>entity.ID == id);
        }

        public async Task<T?> GetWithSpecAsync(ISpecifications<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecifications<T> specification)
        {
            return SpecificationEvaluator<T>.CreateQuery(storeContext.Set<T>(), specification);
        }
    }
}
