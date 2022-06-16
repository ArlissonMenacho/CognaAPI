using CognaAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CognaAPI.Configuration
{
    public static class AddDatabases
    {
        public static void AddDatabaseInfrastructure(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<CognaDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("CognaDatabase"),
                     sqlServerOptionsAction: sqlOptions =>
                     {
                         sqlOptions.EnableRetryOnFailure();
                     }
                );
            });
        }
    }
}
