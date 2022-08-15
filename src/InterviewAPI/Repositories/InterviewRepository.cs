using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InterviewAPI.Context;
using InterviewAPI.Models;
using InterviewAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Repositories
{
    public class InterviewRepository : RepositoryBase<Interview>, IInterviewRepository
    {
        public InterviewRepository(InterviewContext interviewContext) : base(interviewContext)
        {
        }

        public override async Task<List<Interview>> GetAll()
        {
            return await InterviewContext.Set<Interview>()
                .Include(t => t.Interviewee)
                .Include(t => t.Interviewers)
                .AsNoTracking()
                .ToListAsync();
        }
        
        public override async Task<List<Interview>> GetByCondition(Expression<Func<Interview, bool>> expression)
        {
            return await InterviewContext.Set<Interview>()
                .Include(t => t.Interviewee)
                .Include(t => t.Interviewers)
                .Where(expression).AsNoTracking()
                .ToListAsync();
        }

        public override void Create(Interview entity)
        {
            InterviewContext.Set<Interview>().Add(entity);
        }
    }
}