using CognaAPI.Service.Interfaces;
using CognaAPI.Service.Services;

namespace CognaAPI.Configuration
{
    public static class AddServices
    {
        public static void AddServicesExtension(this IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();
        }
    }
}
