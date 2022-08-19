using System;
using System.Threading.Tasks;
using InterviewAPI.Persistence.Abstractions;
using InterviewAPI.Persistence.Abstractions.Commands;
using InterviewAPI.Persistence.Abstractions.Queries;
using InterviewAPI.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewAPI.Persistence.Repositories
{
    // Can be Unit of work
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly InterviewContext _interviewContext;
        private readonly IServiceProvider _serviceProvider;

        public IInterviewCrudRepository InterviewRepository => _serviceProvider.GetService<IInterviewCrudRepository>();
        public IIntervieweeCrudRepository IntervieweeRepository => _serviceProvider.GetService<IIntervieweeCrudRepository>();
        public IInterviewerCrudRepository InterviewerRepository => _serviceProvider.GetService<IInterviewerCrudRepository>();

        public IInterviewerReadOnlyRepository InterviewerReadOnlyRepository => _serviceProvider.GetService<IInterviewerReadOnlyRepository>();
        public IInterviewReadOnlyRepository InterviewReadOnlyRepository => _serviceProvider.GetService<IInterviewReadOnlyRepository>();
        public IIntervieweeReadOnlyRepository IntervieweeReadOnlyRepository => _serviceProvider.GetService<IIntervieweeReadOnlyRepository>();

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