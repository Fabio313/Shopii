using AutoMapper;
using Domain.Entities.v1;

namespace Shopii.Domain.Commands.v1.Users.CreateUser
{
    public class CreateUserCommandProfile : Profile
    {
        public CreateUserCommandProfile()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.Username, src => src.MapFrom(opt => opt.Username))
                .ForMember(dest => dest.Password, src => src.MapFrom(opt => opt.Password))
                .ForMember(dest => dest.Email, src => src.MapFrom(opt => opt.Email))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(opt => opt.CreatedDate));

            CreateMap<User, CreateUserCommandResponse>()
                .ForMember(dest => dest.Id, src => src.MapFrom(opt => opt.Id))
                .ForMember(dest => dest.Username, src => src.MapFrom(opt => opt.Username))
                .ForMember(dest => dest.Email, src => src.MapFrom(opt => opt.Email))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(opt => opt.CreatedDate));
        }
    }
}
