using InterviewAPI.Services.Abstractions.Commands;
using InterviewAPI.Services.Abstractions.Queries;
using InterviewAPI.Services.Services.Commands;
using InterviewAPI.Services.Services.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewAPI.Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IInterviewCommandService, InterviewCommandService>();
            services.AddScoped<IIntervieweeCommandService, IntervieweeCommandService>();
            services.AddScoped<IInterviewerCommandService, InterviewerCommandService>();
            services.AddScoped<IInterviewQueryService, InterviewQueryService>();
            services.AddScoped<IIntervieweeQueryService, IntervieweeQueryService>();
            services.AddScoped<IInterviewerQueryService, InterviewerQueryService>();
            return services;
        }
    }
}