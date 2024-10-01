using Shopii.Domain.Entities.v1;

namespace Shopii.Domain.Interfaces.Repositories.v1
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(string? username = "", string? email = "");
        Task<User?> Login(string username, string password);
        Task<User> CreateUser(User user);
        Task<User> GetUserById(string id);
        Task UpdateUser(User user);
        Task RemoveUser(string id);
    }
}
