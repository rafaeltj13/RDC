using Application.DTO;
using Application.Interface;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Implementation
{
    public class RecipeAppService : IRecipeAppService
    {
        private readonly IRecipeDomainService _recipeService;

        public RecipeAppService(IRecipeDomainService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<ICollection<RecipeDTO>> GetAllAsync()
        {
            var result = await _recipeService.GetAllAsync();
            return AutoMapper.Mapper.Map<ICollection<RecipeDTO>>(result);
        }

        public async Task<RecipeDTO> FindAsync(int id)
        {
            var result = await _recipeService.FindAsync(id);
            return AutoMapper.Mapper.Map<RecipeDTO>(result);
        }

        public Task<RecipeDTO> AddAsync(RecipeDTO recipe)
        {
            throw new NotImplementedException();
        }
    }
}
