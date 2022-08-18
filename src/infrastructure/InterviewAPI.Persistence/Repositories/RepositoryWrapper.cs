using System;
using System.Threading.Tasks;
using InterviewAPI.Persistence.Context;
using InterviewAPI.Persistence.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewAPI.Persistence.Repositories
{
    // Can be Unit of work
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly InterviewContext _interviewContext;
        private readonly IServiceProvider _serviceProvider;
        
        // private IInterviewRepository _interview;
        // private IIntervieweeRepository _interviewee;
        // private IInterviewerRepository _interviewer;

        public IInterviewRepository Interview => _serviceProvider.GetService<IInterviewRepository>();

        public IIntervieweeRepository Interviewee => _serviceProvider.GetService<IIntervieweeRepository>();

        public IInterviewerRepository Interviewer => _serviceProvider.GetService<IInterviewerRepository>();
        
        public async Task Save()
        {
            await _interviewContext.SaveChangesAsync();
        }

        public RepositoryWrapper(InterviewContext interviewContext, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _interviewContext = interviewContext;
        }

    }
}