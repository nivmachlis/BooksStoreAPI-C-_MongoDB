using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDBAPI.Modles;
using MongoDBAPI.Services;

namespace MongoDBAPI.HealthChecks
{
    public class HealthCheck : IHealthCheck
    {
        private readonly IHealthCheckService _healthCheckService;
        private readonly IOptions<DatabaseSettings> _databaseConnection;

        public HealthCheck(IHealthCheckService healthCheckService, IOptions<DatabaseSettings> databaseConnection)
        {
            _healthCheckService = healthCheckService;
            _databaseConnection = databaseConnection;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return _healthCheckService.HealthCheck(_databaseConnection.Value.ConnectionURI);
        }
    }
}
