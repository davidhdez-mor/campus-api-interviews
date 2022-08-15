using System.Collections.Generic;
using System.Linq;
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

        public override IEnumerable<Interview> GetAll()
        {
            return InterviewContext.Set<Interview>()
                .Include(t => t.Interviewee)
                .Include(t => t.Interviewers)
                .AsNoTracking()
                .ToList();
        }
    }
}