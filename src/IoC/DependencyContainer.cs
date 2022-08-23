using InterviewAPI.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InterviewAPI.Persistence;
using InterviewAPI.Dtos;
using InterviewAPI.Services;

namespace IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApi(configuration)
                .AddPersistence(configuration)
                .AddMapping()
                .AddServices();
            
            return services;
        }
    }
}