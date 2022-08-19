using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InterviewAPI.Persistence.Abstractions.ReadOnly;
using InterviewAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Persistence.Repositories.ReadOnly
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class
    {
        protected InterviewContext InterviewContext { get; set; }

        protected ReadOnlyRepository(InterviewContext interviewContext)
        {
            InterviewContext = interviewContext;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await InterviewContext.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await InterviewContext.Set<T>()
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}