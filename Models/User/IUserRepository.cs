namespace TopCoderStarterApp.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        // api/[GET]
        Task<IEnumerable<User>> GetAllUsers();

        // api/1/[GET]
        Task<User> GetUser(long id);

        // api/[POST]
        Task Create(User user);

        // api/[PUT]
        Task<bool> Update(User user);

        // api/1/[DELETE]
        Task<bool> Delete(long id);

        Task<long> GetNextId();
    }
}