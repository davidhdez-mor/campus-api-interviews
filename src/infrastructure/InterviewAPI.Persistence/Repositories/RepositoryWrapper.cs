using System.Threading.Tasks;
using InterviewAPI.Persistence.Context;
using InterviewAPI.Persistence.Repositories.Abstractions;

namespace InterviewAPI.Persistence.Repositories
{
    // Can be Unit of work
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly InterviewContext _interviewContext;
        
        private IInterviewRepository _interview;
        private IIntervieweeRepository _interviewee;
        private IInterviewerRepository _interviewer;

        public IInterviewRepository Interview => _interview ??= new InterviewRepository(_interviewContext);

        public IIntervieweeRepository Interviewee => _interviewee ??= new IntervieweeRepository(_interviewContext);

        public IInterviewerRepository Interviewer => _interviewer ??= new InterviewerRepository(_interviewContext);
        
        public async Task Save()
        {
            await _interviewContext.SaveChangesAsync();
        }

        public RepositoryWrapper(InterviewContext interviewContext)
        {
            _interviewContext = interviewContext;
        }

    }
}