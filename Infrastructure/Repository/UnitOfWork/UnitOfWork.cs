using Infrastructure.Repository.Implementation;
using Infrastructure.Repository.Interface;
using System.Threading.Tasks;

namespace Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Repositories

        private IRecipeRepository _recipeRepository;

        public IRecipeRepository RecipeRepository =>
            _recipeRepository ?? (_recipeRepository = new RecipeRepository(_dataContext));

        #endregion

        public async Task SaveAsync()
        {
            await _dataContext.CommitAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
