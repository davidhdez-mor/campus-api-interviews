using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InterviewAPI.Entities.Models;
using InterviewAPI.Persistence.Abstractions.Queries;
using InterviewAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Persistence.Repositories.Queries
{
    public class InterviewerReadOnlyRepository : ReadOnlyRepository<Interviewer>, IInterviewerReadOnlyRepository
    {
        public InterviewerReadOnlyRepository(InterviewContext interviewContext) : base(interviewContext)
        {
        }
        public override async Task<List<Interviewer>> GetAll()
        {
            return await InterviewContext.Set<Interviewer>()
                .Include(interviewer => interviewer.InterviewInterviewers)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<List<Interviewer>> GetByCondition(Expression<Func<Interviewer, bool>> expression)
        {
            return await InterviewContext.Set<Interviewer>()
                .Include(interviewer => interviewer.InterviewInterviewers)
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}