using Application.DTO;
using AutoMapper;
using Entities;

namespace Application.Mapper
{
    public class EntityMapperProfile : Profile
    {
        public EntityMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
