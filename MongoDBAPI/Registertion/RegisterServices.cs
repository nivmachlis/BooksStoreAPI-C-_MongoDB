using BookStoreApi.Models;
using BookStoreApi.Services;
using MongoDBAPI.HealthChecks;
using MongoDBAPI.Modles;
using MongoDBAPI.Services;

namespace MongoDBAPI.Registertion
{
    public static class RegisterServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<BooksService>();
            services.AddSingleton<IHealthCheckService, HealthCheckService>();
            services.AddHealthChecks().AddCheck<HealthCheck>("Service Heart Beat");
        }
    }
}
