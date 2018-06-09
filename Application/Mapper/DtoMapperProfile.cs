using Application.DTO;
using AutoMapper;
using Entities;

namespace Application.Mapper
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<RecipeDTO, Recipe>();
            CreateMap<UserDTO, User>();
        }
    }
}
