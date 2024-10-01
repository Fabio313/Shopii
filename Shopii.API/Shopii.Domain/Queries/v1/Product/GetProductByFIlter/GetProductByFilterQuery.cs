using MediatR;

namespace Shopii.Domain.Queries.v1.Product.GetProductByFIlter
{
    public class GetProductByFilterQuery : IRequest<GetProductByFilterQueryResponse>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }

        public GetProductByFilterQuery(string? name, string? description, decimal? price, DateTime? createdDate)
        {
            Name = name;
            Description = description;
            Price = price;
            CreatedDate = createdDate;
        }
    }
}
