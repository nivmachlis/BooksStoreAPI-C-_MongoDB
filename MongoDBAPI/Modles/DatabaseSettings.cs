using MongoDB.Driver;

namespace MongoDBAPI.Modles
{
    public class DatabaseSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;

        public IMongoCollection<T> ConnectToMonogo<T>(string collection)
        {
            var mongoClient = new MongoClient(ConnectionURI);

            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);

            return mongoDatabase.GetCollection<T>(collection);
        }
    }
}
