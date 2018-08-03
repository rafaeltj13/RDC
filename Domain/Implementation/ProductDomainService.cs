using Domain.Interface;
using Entities;
using Infrastructure.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Implementation
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }

        public async Task<Product> FindAsync(int id)
        {
            return await _unitOfWork.ProductRepository.FindAsync(id);
        }

        public async Task<ICollection<Product>> GetByFirstLetterAsync(char letter)
        {
            return await _unitOfWork.ProductRepository.GetByFirstLetterAsync(letter);
        }

        public async Task<Product> InsertAsync(Product entity)
        {
            await _unitOfWork.ProductRepository.InsertAsync(entity);

            await _unitOfWork.SaveAsync();

            return entity;
        }

        public async Task<Product> UpdateAsync(Product entity, object key)
        {
            await _unitOfWork.ProductRepository.UpdateAsync(entity, key);

            await _unitOfWork.SaveAsync();

            return entity;
        }

        public async Task DeleteAsync(object key)
        {
            await _unitOfWork.ProductRepository.DeleteAsync(key);

            await _unitOfWork.SaveAsync();
        }
    }
}
