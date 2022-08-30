using InterviewAPI.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InterviewAPI.Persistence;
using InterviewAPI.Dtos;
using InterviewAPI.Services;
using Microsoft.AspNetCore.Builder;

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

        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseGlobalExceptionHandler();
            return app;
        }
    }
}