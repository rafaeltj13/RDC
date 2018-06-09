using Domain.Interface;
using Entities;
using Infrastructure.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Implementation
{
    public class RecipeDomainService : IRecipeDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Recipe>> GetAllAsync()
        {
            return await _unitOfWork.RecipeRepository.GetAllAsync();
        }

        public Task<Recipe> AddAsync(Recipe entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> FindAsync(int id)
        {
            return await _unitOfWork.RecipeRepository.FindAsync(id);
        }

        public Task<Recipe> InsertAsync(Recipe entity)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> UpdateAsync(Recipe entity, object key)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(object key)
        {
            throw new NotImplementedException();
        }

        Task IBaseService<Recipe>.DeleteAsync(object key)
        {
            throw new NotImplementedException();
        }
    }
}
