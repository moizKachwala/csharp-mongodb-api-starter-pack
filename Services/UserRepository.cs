namespace TopCoderStarterApp.Models
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserRepository
    {
        private readonly ApiDBContext _context;

        public UserRepository(ApiDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all users from database
        /// </summary>
        /// <returns>List of Users</returns>
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context
                            .Users
                            .Find(_ => true)
                            .ToListAsync();
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User based on Id</returns>
        public Task<User> GetUser(long id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(m => m.Id, id);
            return _context
                    .Users
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        /// <summary>
        ///  Creates the User
        /// </summary>
        /// <param name="user">Input the user object</param>
        /// <returns>newly constructed user</returns>
        public async Task Create(User user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user">Input user object</param>
        /// <returns>udpated user</returns>
        public async Task<bool> Update(User user)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Users
                        .ReplaceOneAsync(
                            filter: g => g.Id == user.Id,
                            replacement: user);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        /// <summary>
        /// Deletes the user based on Id
        /// </summary>
        /// <param name="id">Input Id of user</param>
        /// <returns>if successful => 1 else 0</returns>
        public async Task<bool> Delete(long id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .Users
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<long> GetNextId()
        {
            return await _context.Users.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}