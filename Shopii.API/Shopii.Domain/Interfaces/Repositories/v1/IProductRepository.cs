using Shopii.Domain.Entities.v1;

namespace Shopii.Domain.Interfaces.Repositories.v1
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(Product filter);
        Task<bool> CreateProduct(Product user);
    }
}
