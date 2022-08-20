using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InterviewAPI.Entities.Models;
using InterviewAPI.Persistence.Abstractions.Crud;
using InterviewAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Persistence.Repositories.Crud
{
    public class IntervieweeCrudRepository : CrudRepository<Interviewee>, IIntervieweeCrudRepository
    {
        public IntervieweeCrudRepository(InterviewContext interviewContext) : base(interviewContext)
        {
            
        }

        public override async Task<List<Interviewee>> GetAll()
        {
            return await InterviewContext.Set<Interviewee>()
                .ToListAsync();
        }

        public override async Task<List<Interviewee>> GetByCondition(Expression<Func<Interviewee, bool>> expresion)
        {
            return await InterviewContext.Set<Interviewee>()
                .Where(expresion)
                .ToListAsync();
        }
        
        public override void Create(Interviewee entity)
        {
            InterviewContext.Set<Interviewee>().Add(entity);
        }
    }
}