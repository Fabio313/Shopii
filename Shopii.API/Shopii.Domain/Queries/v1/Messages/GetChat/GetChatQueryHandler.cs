using AutoMapper;
using Domain.Entities.v1;
using Domain.Interfaces.Repositories.v1;
using Domain.Queries.v1.Messages.GetChat;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;

namespace Shopii.Domain.Queries.v1.Messages.GetChat
{
    public class GetChatQueryHandler : IRequestHandler<GetChatQuery, GetChatQueryResponse>
    {
        private readonly IMessageRepository _messageRepository;
        public IMapper Mapper { get; set; }
        public ILogger Logger { get; set; }

        public GetChatQueryHandler(
            IMessageRepository userRepository,
            IMapper mapper,
            ILoggerFactory logger)
        {
            _messageRepository = userRepository;
            Mapper = mapper;
            Logger = logger.CreateLogger<GetChatQueryHandler>();
        }

        async Task<GetChatQueryResponse> IRequestHandler<GetChatQuery, GetChatQueryResponse>.Handle(GetChatQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Inicio metodo {nameof(GetChatQueryHandler)}.{nameof(Handle)}");

                var response = await _messageRepository.GetChat(request.Sender, request.Reciver);

                Logger.LogInformation($"Fim metodo {nameof(GetChatQueryHandler)}.{nameof(Handle)}");

                return new GetChatQueryResponse() { Messages = Mapper.Map<IEnumerable<MessagesResponse>>(response) };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Erro metodo {nameof(GetChatQueryHandler)}.{nameof(Handle)}");

                throw;
            }
        }
    }
}
