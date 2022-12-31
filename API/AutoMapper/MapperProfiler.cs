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
        }
    }
}
