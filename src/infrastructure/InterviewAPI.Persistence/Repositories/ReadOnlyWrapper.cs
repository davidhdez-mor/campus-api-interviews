using System;
using InterviewAPI.Persistence.Abstractions;
using InterviewAPI.Persistence.Abstractions.ReadOnly;
using InterviewAPI.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewAPI.Persistence.Repositories
{
    public class ReadOnlyWrapper : IReadOnlyWrapper
    {
        private readonly IServiceProvider _serviceProvider;
        
        public IInterviewerReadOnlyRepository InterviewerReadOnlyRepository => _serviceProvider.GetService<IInterviewerReadOnlyRepository>();
        public IInterviewReadOnlyRepository InterviewReadOnlyRepository => _serviceProvider.GetService<IInterviewReadOnlyRepository>();
        public IIntervieweeReadOnlyRepository IntervieweeReadOnlyRepository => _serviceProvider.GetService<IIntervieweeReadOnlyRepository>();
        
        public ReadOnlyWrapper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}