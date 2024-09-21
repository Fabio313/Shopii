using Microsoft.Extensions.Options;
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

        public async Task<IEnumerable<Product>> GetProductsPaginated(int pageNumber, int pageSize)
        {
            return await _ProductCollection
                .Find(Builders<Product>.Filter.Empty)
                .Skip((pageNumber - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();
        }


        public async Task<Product> CreateProduct(Product product)
        {
            await _ProductCollection.InsertOneAsync(product);
            return product;
        }
    }
}
