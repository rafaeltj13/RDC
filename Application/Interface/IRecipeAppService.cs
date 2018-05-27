using Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IRecipeAppService
    {
        Task<ICollection<RecipeDTO>> GetAllAsync();
        Task<RecipeDTO> FindAsync(int id);
        Task<RecipeDTO> AddAsync(RecipeDTO recipe);
    }
}
