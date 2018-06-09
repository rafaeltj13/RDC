using Application.DTO;
using AutoMapper;
using Entities;

namespace Application.Mapper
{
    public class EntityMapperProfile : Profile
    {
        public EntityMapperProfile()
        {
            CreateMap<Recipe, RecipeDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
