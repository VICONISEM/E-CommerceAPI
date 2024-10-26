using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications
{
    public  class SpecifiecationEvaluator<TEntity,Tkey> where TEntity :BaseEntity<Tkey>
    {
        public static IQueryable<TEntity>GetQuery(IQueryable<TEntity> InputQuery,ISpecification<TEntity>Specs)
        {
            var query = InputQuery;
            if(Specs.Criteria is not null)
            {
                query = query.Where(Specs.Criteria);

            }

            if(Specs.OrderByAsc is not null)
            {
                query = query.OrderBy(Specs.OrderByAsc);
            }

            if(Specs.OrderByDesc is not null)
            {
                query = query.OrderByDescending(Specs.OrderByDesc);
            }


            if(Specs.IsPaginated)
            {
                query = query.Skip(Specs.Skip).Take(Specs.Take);
            }

            query = Specs.Includes.Aggregate(query, (current, Includex) => current.Include(Includex));
            return query;
        }
    }
}
