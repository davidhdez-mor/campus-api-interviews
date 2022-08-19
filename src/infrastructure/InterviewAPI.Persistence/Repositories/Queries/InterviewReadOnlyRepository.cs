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
    public class InterviewReadOnlyRepository : ReadOnlyRepository<Interview>, IInterviewReadOnlyRepository
    {
        public InterviewReadOnlyRepository(InterviewContext interviewContext) : base(interviewContext)
        {
        }

        public override async Task<List<Interview>> GetAll()
        {
            return await InterviewContext.Set<Interview>()
                .Include(interview => interview.Interviewee)
                .Include(interview => interview.InterviewInterviewers)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<List<Interview>> GetByCondition(Expression<Func<Interview, bool>> expression)
        {
            return await InterviewContext.Set<Interview>()
                .Include(interview => interview.Interviewee)
                .Include(interview => interview.InterviewInterviewers)      
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}