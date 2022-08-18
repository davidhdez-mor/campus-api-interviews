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
    public class InterviewRepository : RepositoryBase<Interview>, IInterviewRepository
    {
        public InterviewRepository(InterviewContext interviewContext) : base(interviewContext)
        {
        }

        public override async Task<List<Interview>> GetAll()
        {
            return await InterviewContext.Set<Interview>()
                .Include(t => t.Interviewee)
                .Include(interview => interview.InterviewerLink
                    .Join(interview.InterviewerLink,
                        ii1 => ii1.InterviewId,
                        ii2 => ii2.InterviewerId,
                        (ii1, ii2) => new
                        {
                            Interview = ii1,
                            Interviewer = ii2
                        }
                    )
                )
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<List<Interview>> GetByCondition(Expression<Func<Interview, bool>> expression)
        {
            return await InterviewContext.Set<Interview>()
                .Include(t => t.Interviewee)
                .Include(t => t.InterviewerLink)
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
        }

        public override void Create(Interview entity)
        {
            InterviewContext.Entry(entity).State = EntityState.Added;
            InterviewContext.Entry(entity.Interviewee).State = EntityState.Unchanged;
            entity.InterviewerLink.ForEach(interviewer =>
                InterviewContext.Entry(interviewer).State = EntityState.Unchanged);
        }

        public override void Update(Interview entity)
        {
            InterviewContext.Entry(entity).State = EntityState.Modified;
            InterviewContext.Entry(entity.Interviewee).State = EntityState.Unchanged;

            // Solo agrega entrevistadores pero no se pueden repetir
            entity.InterviewerLink.ForEach(interviewer =>
                InterviewContext.Entry(interviewer).State = EntityState.Modified);

            // InterviewContext.Set<Interview>().Update(entity);
        }
    }
}