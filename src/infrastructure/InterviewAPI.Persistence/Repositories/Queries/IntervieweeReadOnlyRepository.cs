using InterviewAPI.Entities.Models;
using InterviewAPI.Persistence.Abstractions.Queries;
using InterviewAPI.Persistence.Context;

namespace InterviewAPI.Persistence.Repositories.Queries
{
    public class IntervieweeReadOnlyRepository : ReadOnlyRepository<Interviewee>, IIntervieweeReadOnlyRepository
    {
        public IntervieweeReadOnlyRepository(InterviewContext interviewContext) : base(interviewContext)
        {
        }
    }
}