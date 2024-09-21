using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopii.Domain.Interfaces.Repositories.v1;

namespace Shopii.Domain.Commands.v1.Products.GetProductsPaginated
{
    public class GetProductsPaginatedCommandHandler : IRequestHandler<GetProductsPaginatedCommand, GetProductsPaginatedCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        public IMapper Mapper { get; set; }
        public ILogger Logger { get; set; }

        public GetProductsPaginatedCommandHandler(
            IProductRepository userRepository,
            IMapper mapper,
            ILoggerFactory logger)
        {
            _productRepository = userRepository;
            Mapper = mapper;
            Logger = logger.CreateLogger<GetProductsPaginatedCommandHandler>();
        }

        public async Task<GetProductsPaginatedCommandResponse> Handle(GetProductsPaginatedCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Inicio metodo {nameof(GetProductsPaginatedCommandHandler)}.{nameof(Handle)}");

                var response = await _productRepository.GetProductsPaginated(request.PageNumber, request.PageSize);

                Logger.LogInformation($"Fim metodo {nameof(GetProductsPaginatedCommandHandler)}.{nameof(Handle)}");

                return new GetProductsPaginatedCommandResponse() { Products = Mapper.Map<IEnumerable<ProductResponse>>(response) };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Erro metodo {nameof(GetProductsPaginatedCommandHandler)}.{nameof(Handle)}");

                throw;
            }
        }
    }
}
