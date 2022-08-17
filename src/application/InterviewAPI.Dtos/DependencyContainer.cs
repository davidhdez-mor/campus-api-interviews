using Microsoft.Extensions.DependencyInjection;

namespace InterviewAPI.Dtos
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DependencyContainer));
            return services;
        }
    }
}