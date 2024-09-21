using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopii.CrossCutting.Exceptions;
using Shopii.CrossCutting.Helper;
using Shopii.Domain.Entities.v1;
using Shopii.Domain.Interfaces.Repositories.v1;
using System.Reflection.Metadata;

namespace Shopii.Domain.Commands.v1.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        public IMapper Mapper { get; set; }
        public ILogger Logger { get; set; }

        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IMapper mapper,
            ILoggerFactory logger)
        {
            _userRepository = userRepository;
            Mapper = mapper;
            Logger = logger.CreateLogger<CreateUserCommandHandler>();
        }

        async Task<CreateUserCommandResponse> IRequestHandler<CreateUserCommand, CreateUserCommandResponse>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Inicio metodo {nameof(CreateUserCommandHandler)}.{nameof(Handle)}");

                var user = Mapper.Map<User>(request);

                user.Password = HashingHelper.ComputeSha256Hash(request.Password);

                var response = await _userRepository.CreateUser(user);

                Logger.LogInformation($"Fim metodo {nameof(CreateUserCommandHandler)}.{nameof(Handle)}");

                return Mapper.Map<CreateUserCommandResponse>(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Erro metodo {nameof(CreateUserCommandHandler)}.{nameof(Handle)}");

                throw;
            }
        }
    }
}
