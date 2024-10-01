using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Shopii.CrossCutting;
using Shopii.Domain.Entities.v1;
using Shopii.Domain.Interfaces.Repositories.v1;

namespace Shopii.Infraestructure.Data.Repositories.v1
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _ProductCollection;

        public ProductRepository(
            IMongoClient mongoClient,
            IOptions<AppSettingsConfigurations> appSettings)
        {
            var database = mongoClient.GetDatabase(appSettings.Value.MongoDBSettings.DatabaseName);
            _ProductCollection = database.GetCollection<Product>(appSettings.Value.MongoDBSettings.ProductsCollection);
        }

        public async Task<IEnumerable<Product>> GetProducts(Product productFilter)
        {
            var filter = Builders<Product>.Filter.Empty;

            filter = Builders<Product>.Filter.And(filter, Builders<Product>.Filter.Regex(u => u.Sender, new BsonRegularExpression(sender, "i")));
            filter = Builders<Product>.Filter.And(filter, Builders<Product>.Filter.Regex(u => u.Reciver, new BsonRegularExpression(reciver, "i")));

            var result = await _ProductCollection.Find(filter).ToListAsync();

            return result;
        }

        public async Task<bool> CreateProduct(Product Product)
        {
            await _ProductCollection.InsertOneAsync(Product);
            return true;
        }
    }
}
