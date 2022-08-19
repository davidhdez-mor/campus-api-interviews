using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InterviewAPI.Persistence.Abstractions.Queries
{
    public interface IReadOnlyRepository<T>
    {
        public Task<List<T>> GetAll();
        public Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression);
        
    }
}