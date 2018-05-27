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
    }
}
