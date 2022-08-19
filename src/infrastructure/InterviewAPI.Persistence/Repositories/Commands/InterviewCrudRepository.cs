using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InterviewAPI.Entities.Models;
using InterviewAPI.Persistence.Abstractions.Commands;
using InterviewAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Persistence.Repositories.Commands
{
    public class InterviewCrudRepository : CrudRepository<Interview>, IInterviewCrudRepository
    {
        public InterviewCrudRepository(InterviewContext interviewContext) : base(interviewContext)
        {
        }

        public override async Task<List<Interview>> GetAll()
        {
            return await InterviewContext.Set<Interview>()
                .Include(t => t.Interviewee)
                .Include(t => t.Interviewers)
                .ToListAsync();
        }

        public override async Task<List<Interview>> GetByCondition(Expression<Func<Interview, bool>> expression)
        {
            return await InterviewContext.Set<Interview>()
                .Include(t => t.Interviewee)
                .Include(t => t.Interviewers)
                .Where(expression)
                .ToListAsync();
        }

        public override void Create(Interview entity)
        {
            InterviewContext.Entry(entity).State = EntityState.Added;
            InterviewContext.Entry(entity.Interviewee).State = EntityState.Unchanged;
            foreach (var interviewer in entity.Interviewers)
            {
                InterviewContext.Entry(interviewer).State = EntityState.Unchanged;
            }
        }

        public override void Update(Interview entity)
        {
            InterviewContext.Entry(entity).State = EntityState.Modified;
        }
    }
}