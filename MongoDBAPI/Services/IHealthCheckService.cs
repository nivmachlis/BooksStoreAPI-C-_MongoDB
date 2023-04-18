using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDBAPI.Modles;

namespace MongoDBAPI.Services
{
    public interface IHealthCheckService
    {
        public Task<HealthCheckResult> HealthCheck(string connectionString);
    }
}
