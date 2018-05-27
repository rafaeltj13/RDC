using Entities;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Repository.Implementation
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
