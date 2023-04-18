namespace MongoDBAPI.EndPoints
{
    public static class MappingHealthChecks
    {
        public static void MapHealthChecks(this IEndpointRouteBuilder app)
        {
            app.MapHealthChecks("/DBHealth");
        }
    }
}
