﻿using Infrastructure.Repository.Interface;
using System.Threading.Tasks;

namespace Infrastructure.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRecipeRepository RecipeRepository { get; }

        Task SaveAsync();
    }
}
