using AutoMapper;
using Shopii.Domain.Entities.v1;

namespace Shopii.Domain.Commands.v1.Products.CreateProduct
{
    public class CreateProductCommandProfile : Profile
    {
        public CreateProductCommandProfile() 
        {
            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.Name, src => src.MapFrom(opt => opt.Name))
                .ForMember(dest => dest.Description, src => src.MapFrom(opt => opt.Description))
                .ForMember(dest => dest.Price, src => src.MapFrom(opt => opt.Price))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(opt => opt.CreatedDate));
        }
    }
}
