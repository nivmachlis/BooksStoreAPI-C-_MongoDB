using MongoDBAPI.Modles;

namespace MongoDBAPI.Registertion
{
    public static class DataAccessControl
    {
        public static void AddDataAccessControl(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<DatabaseSettings>(
                builder.Configuration.GetSection("MongoDB"));
        }
    }
}
