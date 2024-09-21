using Shopii.Domain.Entities.v1;

namespace Shopii.Domain.Interfaces.Repositories.v1
{
    public interface IUserRepository
    {
        Task<User?> Login(string username, string password);
        Task<User> CreateUser(User user);
    }
}
