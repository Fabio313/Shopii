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

            if (!string.IsNullOrEmpty(productFilter.Name))
            {
                filter = Builders<Product>.Filter.And(filter, Builders<Product>.Filter.Regex(p => p.Name, new BsonRegularExpression(productFilter.Name, "i")));
            }

            if (!string.IsNullOrEmpty(productFilter.Description))
            {
                filter = Builders<Product>.Filter.And(filter, Builders<Product>.Filter.Regex(p => p.Description, new BsonRegularExpression(productFilter.Description, "i")));
            }

            if (productFilter.Price > 0)
            {
                filter = Builders<Product>.Filter.And(filter, Builders<Product>.Filter.Eq(p => p.Price, productFilter.Price));
            }

            if (productFilter.CreatedDate != default)
            {
                filter = Builders<Product>.Filter.And(filter, Builders<Product>.Filter.Eq(p => p.CreatedDate, productFilter.CreatedDate));
            }

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
