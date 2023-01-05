using Application.DTOs;
using AutoMapper;
using Domain;

namespace API.AutoMapper
{
    public class MapperProfiler : Profile
    {
        public MapperProfiler()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Categories, CategoriesDTO>()
                .ForMember(x => x.CategoryId, opt => opt.MapFrom(t => t.Id))
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(t => t.Name));
            CreateMap<CategoriesDTO, Categories>()
                .ForMember(x => x.Name, opt => opt.MapFrom(t => t.CategoryName))
                .ForMember(x => x.Id, opt => opt.MapFrom(t => t.CategoryId));
        }
    }
}
