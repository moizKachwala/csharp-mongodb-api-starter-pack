namespace TopCoderStarterApp.Models
{
    using TopCoderStarterApp;
    using MongoDB.Driver;

    public class UserContext
    {
        private readonly IMongoDatabase _db;

        public UserContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<User> Users => _db.GetCollection<User>("Users");
    }
}