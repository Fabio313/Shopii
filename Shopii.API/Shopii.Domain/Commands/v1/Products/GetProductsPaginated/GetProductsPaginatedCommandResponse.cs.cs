namespace Shopii.Domain.Commands.v1.Products.GetProductsPaginated
{
    public class GetProductsPaginatedCommandResponse
    {
        public IEnumerable<ProductResponse> Products { get; set; }
    }

    public class ProductResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
