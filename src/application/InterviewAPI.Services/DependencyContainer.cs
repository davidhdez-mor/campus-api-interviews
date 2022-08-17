using InterviewAPI.Services.Services;
using InterviewAPI.Services.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewAPI.Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IInterviewService, InterviewService>();
            services.AddScoped<IIntervieweeService, IntervieweeService>();
            services.AddScoped<IInterviewerService, InterviewerService>();
            return services;
        }
    }
}