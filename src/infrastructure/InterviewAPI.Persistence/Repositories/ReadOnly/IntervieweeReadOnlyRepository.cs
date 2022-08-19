using InterviewAPI.Entities.Models;
using InterviewAPI.Persistence.Abstractions.ReadOnly;
using InterviewAPI.Persistence.Context;

namespace InterviewAPI.Persistence.Repositories.ReadOnly
{
    public class IntervieweeReadOnlyRepository : ReadOnlyRepository<Interviewee>, IIntervieweeReadOnlyRepository
    {
        public IntervieweeReadOnlyRepository(InterviewContext interviewContext) : base(interviewContext)
        {
        }
    }
}