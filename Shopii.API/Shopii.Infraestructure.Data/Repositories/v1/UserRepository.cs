using Shopii.CrossCutting;
using Shopii.Domain.Entities.v1;
using Shopii.Domain.Interfaces.Repositories.v1;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Shopii.Infrastructure.Data.Repositories.v1
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserRepository(
            IMongoClient mongoClient,
            IOptions<AppSettingsConfigurations> appSettings)
        {
            var database = mongoClient.GetDatabase(appSettings.Value.MongoDBSettings.DatabaseName);
            _usersCollection = database.GetCollection<User>(appSettings.Value.MongoDBSettings.UsersCollection);
        }

        public async Task<User> CreateUser(User user)
        {
            await _usersCollection.InsertOneAsync(user);
            return user;
        }

        public async Task<User?> Login(string username, string password)
        {
            var user = await _usersCollection.Find(u => u.Username == username).FirstOrDefaultAsync();

            if (user == null)
                return null;

            return string.Equals(password, user.Password) ? user : null;
        }
    }
}
