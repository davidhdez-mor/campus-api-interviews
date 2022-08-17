using InterviewAPI.Persistence.Context;
using InterviewAPI.Persistence.Repositories;
using InterviewAPI.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewAPI.Persistence
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InterviewContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                    x => x.MigrationsAssembly(typeof(InterviewContext).Assembly.GetName().Name)));
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            return services;
        }
    }
}