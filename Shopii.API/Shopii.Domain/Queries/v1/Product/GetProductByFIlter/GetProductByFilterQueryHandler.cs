using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopii.Domain.Interfaces.Repositories.v1;
using System.Reflection.Metadata;

namespace Shopii.Domain.Queries.v1.Product.GetProductByFIlter
{
    public class GetChatQueryHandler : IRequestHandler<GetProductByFilterQuery, GetProductByFilterQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        public IMapper Mapper { get; set; }
        public ILogger Logger { get; set; }

        public GetChatQueryHandler(
            IProductRepository productRepository,
            IMapper mapper,
            ILoggerFactory logger)
        {
            _productRepository = productRepository;
            Mapper = mapper;
            Logger = logger.CreateLogger<GetChatQueryHandler>();
        }

        async Task<GetProductByFilterQueryResponse> IRequestHandler<GetProductByFilterQuery, GetProductByFilterQueryResponse>.Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Inicio metodo {nameof(GetChatQueryHandler)}.{nameof(Handle)}");

                var response = await _productRepository.GetProducts(Mapper.Map<Entities.v1.Product>(request));

                Logger.LogInformation($"Fim metodo {nameof(GetChatQueryHandler)}.{nameof(Handle)}");

                return new GetProductByFilterQueryResponse() { Products = Mapper.Map<IEnumerable<ProductsResponse>>(response) };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Erro metodo {nameof(GetChatQueryHandler)}.{nameof(Handle)}");

                throw;
            }
        }
    }
}
