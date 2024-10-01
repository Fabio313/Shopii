using AutoMapper;

namespace Shopii.Domain.Queries.v1.Product.GetProductByFIlter
{
    public class GetProductByFilterQueryProfile : Profile
    {
        public GetProductByFilterQueryProfile()
        {
            CreateMap<Entities.v1.Product, ProductsResponse>()
                .ForMember(dest => dest.Name, src => src.MapFrom(opt => opt.Name))
                .ForMember(dest => dest.Description, src => src.MapFrom(opt => opt.Description))
                .ForMember(dest => dest.Price, src => src.MapFrom(opt => opt.Price))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(opt => opt.CreatedDate));

            CreateMap<GetProductByFilterQuery, Entities.v1.Product>()
                .ForMember(dest => dest.Name, src => src.MapFrom(opt => opt.Name))
                .ForMember(dest => dest.Description, src => src.MapFrom(opt => opt.Description))
                .ForMember(dest => dest.Price, src => src.MapFrom(opt => opt.Price))
                .ForMember(dest => dest.CreatedDate, src => src.MapFrom(opt => opt.CreatedDate));
        }
    }
}
