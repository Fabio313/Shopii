using AutoMapper;
using Shopii.Domain.Entities.v1;

namespace Shopii.Domain.Commands.v1.Products.GetProductsPaginated
{
    public class GetProductsPaginatedCommandProfile : Profile
    {
        public GetProductsPaginatedCommandProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.Name, src => src.MapFrom(opt => opt.Name))
                .ForMember(dest => dest.Description, src => src.MapFrom(opt => opt.Description))
                .ForMember(dest => dest.Price, src => src.MapFrom(opt => opt.Price));
        }
    }
}
