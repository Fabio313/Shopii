using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopii.CrossCutting.Helper;
using Shopii.Domain.Interfaces.Repositories.v1;
using System.Reflection.Metadata;

namespace Shopii.Domain.Commands.v1.Users.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        public IMapper Mapper { get; set; }
        public ILogger Logger { get; set; }

        public LoginUserCommandHandler(
            IUserRepository userRepository,
            IMapper mapper,
            ILoggerFactory logger)
        {
            _userRepository = userRepository;
            Mapper = mapper;
            Logger = logger.CreateLogger<LoginUserCommandHandler>();
        }

        async Task<LoginUserCommandResponse> IRequestHandler<LoginUserCommand, LoginUserCommandResponse>.Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Inicio metodo {nameof(LoginUserCommandHandler)}.{nameof(Handle)}");

                request.Password = HashingHelper.ComputeSha256Hash(request.Password);

                var response = await _userRepository.Login(request.Username, request.Password);

                Logger.LogInformation($"Fim metodo {nameof(LoginUserCommandHandler)}.{nameof(Handle)}");

                return Mapper.Map<LoginUserCommandResponse>(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Erro metodo {nameof(LoginUserCommandHandler)}.{nameof(Handle)}");

                throw;
            }
        }
    }
}
