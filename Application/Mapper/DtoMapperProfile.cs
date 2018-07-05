using Application.DTO;
using AutoMapper;
using Entities;

namespace Application.Mapper
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<ProductDTO, Product>();
            CreateMap<StockDTO, Stock>();
        }
    }
}
