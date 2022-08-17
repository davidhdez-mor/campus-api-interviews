using Microsoft.Extensions.DependencyInjection;

namespace InterviewAPI.Api
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }
    }
}