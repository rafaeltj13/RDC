using Domain.Interface;
using Entities;
using Infrastructure.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Implementation
{
    public class StockDomainService : IStockDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Stock>> GetAllAsync()
        {
            return await _unitOfWork.StockRepository.GetAllAsync();
        }

        public async Task<Stock> FindAsync(int id)
        {
            return await _unitOfWork.StockRepository.FindAsync(id);
        }

        public async Task<Stock> InsertAsync(Stock entity)
        {
            await _unitOfWork.StockRepository.InsertAsync(entity);

            await _unitOfWork.SaveAsync();

            return entity;
        }

        public async Task<Stock> UpdateAsync(Stock entity, object key)
        {
            await _unitOfWork.StockRepository.UpdateAsync(entity, key);

            await _unitOfWork.SaveAsync();

            return entity;
        }

        public async Task DeleteAsync(object key)
        {
            await _unitOfWork.StockRepository.DeleteAsync(key);

            await _unitOfWork.SaveAsync();
        }
    }
}
