using MediatR;

namespace Shopii.Domain.Commands.v1.Products.GetProductsPaginated
{
    public class GetProductsPaginatedCommand : IRequest<GetProductsPaginatedCommandResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
