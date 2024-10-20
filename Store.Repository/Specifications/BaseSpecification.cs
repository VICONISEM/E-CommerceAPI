using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Store.Repository.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {


        public BaseSpecification(Expression<Func<T,bool>> criteria) { 
        
           Criteria = criteria;
        
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderByAsc { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginated { get; private set; }

        protected void AddInclude(Expression<Func<T,object>> includeEx)
            =>Includes.Add(includeEx);

        protected void AddOrderByAsc(Expression<Func<T, object>> Order)
            => OrderByAsc = Order;

        protected void AddOrderByDesc(Expression<Func<T,object>> Order)
            =>OrderByDesc = Order;


        protected void ApplayPagination(int _Skip, int _Take)
        {
            Skip = _Skip;
            Take = _Take;
            IsPaginated = true;
        }


    }
}
