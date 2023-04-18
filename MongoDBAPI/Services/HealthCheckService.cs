using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBAPI.Modles;

namespace MongoDBAPI.Services
{
    public class HealthCheckService : IHealthCheckService
    {

        async Task<HealthCheckResult> IHealthCheckService.HealthCheck(string connectionString)
        {
            HealthCheckResult result;
            var mongoClient = new MongoClient(connectionString);

            try
            {
                await mongoClient.StartSessionAsync(); // Ping the server
                result = new HealthCheckResult(HealthStatus.Healthy, "Connection to the database is alive!");
            }
            catch (Exception ex)
            {
                result = new HealthCheckResult(HealthStatus.Unhealthy, $"Failed to connect to the database: {ex.Message}");
            }
            return result;
        }
    }

}