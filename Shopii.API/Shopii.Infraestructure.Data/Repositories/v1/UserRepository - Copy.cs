using Shopii.CrossCutting;
using Shopii.Domain.Entities.v1;
using Shopii.Domain.Interfaces.Repositories.v1;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

        public async Task<IEnumerable<User>> GetUsers(string? username = "", string? email = "")
        {
            var filter = Builders<User>.Filter.Empty;

            if (!string.IsNullOrEmpty(username))
            {
                filter = Builders<User>.Filter.And(filter, Builders<User>.Filter.Regex(u => u.Username, new BsonRegularExpression(username, "i")));
            }

            if (!string.IsNullOrEmpty(email))
            {
                filter = Builders<User>.Filter.And(filter, Builders<User>.Filter.Regex(u => u.Email, new BsonRegularExpression(email, "i")));
            }

            return await _usersCollection.Find(filter).ToListAsync();
        }


        public async Task<User> GetUserById(string id)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, id);
            return (await _usersCollection.FindAsync(filter)).FirstOrDefault();
        }

        public async Task RemoveUser(string id)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, id);
            await _usersCollection.DeleteOneAsync(filter);
        }

        public async Task UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            await _usersCollection.ReplaceOneAsync(filter, user);
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
