using InterviewAPI.Context;
using InterviewAPI.Repositories.Abstractions;

namespace InterviewAPI.Repositories
{
    // Can be Unit of work
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IInterviewRepository _interview;
        
        public IInterviewRepository Interview
        {
            get
            {
                if (_interview is null)
                    _interview = new InterviewRepository(_interviewContext);

                return _interview;
            }
        }

        private readonly InterviewContext _interviewContext;
        
        public void Save()
        {
            _interviewContext.SaveChanges();
        }

        public RepositoryWrapper(InterviewContext interviewContext)
        {
            _interviewContext = interviewContext;
        }

    }
}