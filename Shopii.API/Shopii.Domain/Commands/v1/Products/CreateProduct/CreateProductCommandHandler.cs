using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopii.Domain.Commands.v1.Users.CreateUser;
using Shopii.Domain.Entities.v1;
using Shopii.Domain.Interfaces.Repositories.v1;
using System.Reflection.Metadata;

namespace Shopii.Domain.Commands.v1.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        public IMapper Mapper { get; set; }
        public ILogger Logger { get; set; }

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper,
            ILoggerFactory logger)
        {
            _productRepository = productRepository;
            Mapper = mapper;
            Logger = logger.CreateLogger<CreateProductCommandHandler>();
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        { 
            try
            {
                Logger.LogInformation($"Inicio metodo {nameof(CreateProductCommandHandler)}.{nameof(Handle)}");

                var product = Mapper.Map<Product>(request);

                var response = await _productRepository.CreateProduct(product);

                Logger.LogInformation($"Fim metodo {nameof(CreateProductCommandHandler)}.{nameof(Handle)}");

                return Mapper.Map<CreateProductCommandResponse>(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Erro metodo {nameof(CreateProductCommandHandler)}.{nameof(Handle)}");

                throw;
            }
        }
    }
}
