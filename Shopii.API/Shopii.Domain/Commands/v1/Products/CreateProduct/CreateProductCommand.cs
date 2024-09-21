using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Shopii.Domain.Commands.v1.Products.CreateProduct
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
