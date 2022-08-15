using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using InterviewAPI.Context;
using InterviewAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public InterviewContext InterviewContext { get; set; }

        public RepositoryBase(InterviewContext interviewContext)
        {
            InterviewContext = interviewContext;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return InterviewContext.Set<T>().AsNoTracking();
        }

        public virtual IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return InterviewContext.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual void Create(T entity)
        {
            InterviewContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            InterviewContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            InterviewContext.Set<T>().Remove(entity);
        }
    }
}