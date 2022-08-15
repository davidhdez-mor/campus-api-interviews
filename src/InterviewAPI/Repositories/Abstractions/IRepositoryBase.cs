using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InterviewAPI.Repositories.Abstractions
{
    public interface IRepositoryBase<T>
    {
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}