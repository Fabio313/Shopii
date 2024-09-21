using Shopii.Domain.Entities.v1;

namespace Shopii.Domain.Interfaces.Repositories.v1
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsPaginated(int pageNumber, int pageSize);
        Task<Product> CreateProduct(Product user);
    }
}
