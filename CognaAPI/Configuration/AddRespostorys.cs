using CognaAPI.Infra.Repository;
using CognaAPI.Infra.Repository.Interfaces;

namespace CognaAPI.Configuration
{
    public static class AddRespostorys
    {
        public static void AddRepositorysExtension(this IServiceCollection services)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();
        }

    }
}
