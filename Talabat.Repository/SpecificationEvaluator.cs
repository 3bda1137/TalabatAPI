using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    internal static class SpecificationEvaluator<T> where T : BaseEntity
    {

        public static IQueryable<T> CreateQuery(IQueryable<T> store,ISpecifications<T> spec)
        {
            var query=store;

            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);
           query=spec.Includes.Aggregate(query,(current,includeExepression)=>current.Include(includeExepression));
            return query;
        }

    }
}
