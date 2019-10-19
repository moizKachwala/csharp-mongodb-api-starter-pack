namespace TopCoderStarterApp.Models
{
    using MongoDB.Driver;
    using TopCoderStarterApp;

    public class ApiDBContext
    {
        private readonly IMongoDatabase _db;

        public ApiDBContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<User> Users => _db.GetCollection<User>("Users");
    }
}