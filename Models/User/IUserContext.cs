namespace TopCoderStarterApp.Models
{
    using MongoDB.Driver;

    public interface IUserContext
    {
        IMongoCollection<User> Users { get; }
    }
}