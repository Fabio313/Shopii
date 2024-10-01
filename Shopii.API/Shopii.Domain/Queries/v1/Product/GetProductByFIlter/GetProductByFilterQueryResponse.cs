namespace Shopii.Domain.Queries.v1.Product.GetProductByFIlter
{
    public class GetProductByFilterQueryResponse
    {
        public IEnumerable<ProductsResponse> Products { get; set; }
    }

    public class ProductsResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
