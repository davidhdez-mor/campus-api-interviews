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
    public class IntervieweeRepository : RepositoryBase<Interviewee>, IIntervieweeRepository
    {
        public IntervieweeRepository(InterviewContext interviewContext) : base(interviewContext)
        {
            
        }

        public override async Task<List<Interviewee>> GetAll()
        {
            return await InterviewContext.Set<Interviewee>()
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<List<Interviewee>> GetByCondition(Expression<Func<Interviewee, bool>> expresion)
        {
            return await InterviewContext.Set<Interviewee>()
                .AsNoTracking()
                .Where(expresion)
                .ToListAsync();
        }
        
        public override void Create(Interviewee entity)
        {
            InterviewContext.Set<Interviewee>().Add(entity);
        }
    }
}