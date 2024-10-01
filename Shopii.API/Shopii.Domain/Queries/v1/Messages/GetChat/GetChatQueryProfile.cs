using AutoMapper;
using Domain.Entities.v1;
using Domain.Queries.v1.Messages.GetChat;

namespace Shopii.Domain.Queries.v1.Messages.GetChat
{
    public class GetChatQueryProfile : Profile
    {
        public GetChatQueryProfile()
        {
            CreateMap<Message, MessagesResponse>()
                .ForMember(dest => dest.Sender, src => src.MapFrom(opt => opt.Sender))
                .ForMember(dest => dest.Text, src => src.MapFrom(opt => opt.Text))
                .ForMember(dest => dest.SendDate, src => src.MapFrom(opt => opt.SendDate));
        }
    }
}
