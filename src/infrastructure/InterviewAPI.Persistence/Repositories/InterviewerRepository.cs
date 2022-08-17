using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InterviewAPI.Entities.Models;
using InterviewAPI.Persistence.Context;
using InterviewAPI.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Persistence.Repositories
{
    public class InterviewerRepository : RepositoryBase<Interviewer>, IInterviewerRepository
    {
        public InterviewerRepository(InterviewContext interviewContext) : base(interviewContext)
        {
        }

        public override async Task<List<Interviewer>> GetAll()
        {
            return await InterviewContext.Set<Interviewer>()
                .Include(i => i.Interviews)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<List<Interviewer>> GetByCondition(Expression<Func<Interviewer, bool>> expression)
        {
            return await InterviewContext.Interviewers
                .Include(i => i.Interviews)
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
        }

        public override void Create(Interviewer entity)
        {
            InterviewContext.Set<Interviewer>().Add(entity);
        }
    }
}