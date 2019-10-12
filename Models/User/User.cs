namespace TopCoderStarterApp.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class User
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}