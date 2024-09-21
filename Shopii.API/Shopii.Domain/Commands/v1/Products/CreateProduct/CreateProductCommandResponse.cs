using MediatR;
using System.Text.Json.Serialization;

namespace Shopii.Domain.Commands.v1.Products.CreateProduct
{
    public class CreateProductCommandResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
