using InterviewAPI.Persistence.Abstractions;
using InterviewAPI.Persistence.Abstractions.Crud;
using InterviewAPI.Persistence.Abstractions.ReadOnly;
using InterviewAPI.Persistence.Context;
using InterviewAPI.Persistence.Repositories;
using InterviewAPI.Persistence.Repositories.Crud;
using InterviewAPI.Persistence.Repositories.ReadOnly;
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
            services.AddScoped<IIntervieweeCrudRepository, IntervieweeCrudRepository>();
            services.AddScoped<IInterviewerCrudRepository, InterviewerCrudRepository>();
            services.AddScoped<IInterviewCrudRepository, InterviewCrudRepository>();
            services.AddScoped<IInterviewReadOnlyRepository, InterviewReadOnlyRepository>();
            services.AddScoped<IInterviewerReadOnlyRepository, InterviewerReadOnlyRepository>();
            services.AddScoped<IIntervieweeReadOnlyRepository, IntervieweeReadOnlyRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IReadOnlyWrapper, ReadOnlyWrapper>();
            return services;
        }
    }
}