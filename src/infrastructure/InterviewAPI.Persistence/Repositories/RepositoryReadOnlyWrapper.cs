using System;
using InterviewAPI.Persistence.Abstractions;
using InterviewAPI.Persistence.Abstractions.Queries;
using InterviewAPI.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewAPI.Persistence.Repositories
{
    public class RepositoryReadOnlyWrapper : IRepositoryReadOnlyWrapper
    {
        private readonly InterviewContext _interviewContext;
        private readonly IServiceProvider _serviceProvider;
        
        
        public IInterviewerReadOnlyRepository InterviewerReadOnlyRepository =>
            _serviceProvider.GetService<IInterviewerReadOnlyRepository>();

        public IInterviewReadOnlyRepository InterviewReadOnlyRepository =>
            _serviceProvider.GetService<IInterviewReadOnlyRepository>();

        public IIntervieweeReadOnlyRepository IntervieweeReadOnlyRepository =>
            _serviceProvider.GetService<IIntervieweeReadOnlyRepository>();
        
        public RepositoryReadOnlyWrapper(InterviewContext interviewContext, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _interviewContext = interviewContext;
        }
    }
}