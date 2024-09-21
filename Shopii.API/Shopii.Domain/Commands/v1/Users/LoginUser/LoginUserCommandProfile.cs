using AutoMapper;
using Domain.Entities.v1;

namespace Shopii.Domain.Commands.v1.Users.LoginUser
{
    public class LoginUserCommandProfile : Profile
    {
        public LoginUserCommandProfile()
        {
            CreateMap<User, LoginUserCommandResponse>()
                .ForMember(dest => dest.Id, src => src.MapFrom(opt => opt.Id))
                .ForMember(dest => dest.Username, src => src.MapFrom(opt => opt.Username))
                .ForMember(dest => dest.Email, src => src.MapFrom(opt => opt.Email))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(opt => opt.CreatedDate));
        }
    }
}
