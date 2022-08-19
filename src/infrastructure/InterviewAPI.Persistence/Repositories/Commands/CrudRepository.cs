using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InterviewAPI.Persistence.Abstractions.Commands;
using InterviewAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Persistence.Repositories.Commands
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        protected InterviewContext InterviewContext { get; set; }

        protected CrudRepository(InterviewContext interviewContext)
        {
            InterviewContext = interviewContext;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await InterviewContext.Set<T>().ToListAsync();
        }

        public virtual async Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await InterviewContext.Set<T>().Where(expression).ToListAsync();
        }

        public virtual void Create(T entity)
        {
            InterviewContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            InterviewContext.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            InterviewContext.Set<T>().Remove(entity);
        }
    }
}