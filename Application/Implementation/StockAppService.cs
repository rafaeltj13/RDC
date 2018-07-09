using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementation
{
    public class StockAppService : IStockAppService
    {
        private readonly IStockDomainService _stockService;

        public StockAppService(IStockDomainService stockService)
        {
            _stockService = stockService;
        }

        public async Task<ICollection<StockDTO>> GetAllAsync()
        {
            var result = await _stockService.GetAllAsync();
            return AutoMapper.Mapper.Map<ICollection<StockDTO>>(result);
        }

        public async Task<StockDTO> FindAsync(int id)
        {
            var result = await _stockService.FindAsync(id);
            return AutoMapper.Mapper.Map<StockDTO>(result);
        }

        public async Task<StockDTO> InsertAsync(StockDTO stock)
        {
            var result = await _stockService.InsertAsync(AutoMapper.Mapper.Map<Stock>(stock));
            return AutoMapper.Mapper.Map<StockDTO>(result);
        }

        public async Task<StockDTO> UpdateAsync(int id, StockDTO stock)
        {
            var result = await _stockService.UpdateAsync(AutoMapper.Mapper.Map<Stock>(stock), id);
            return AutoMapper.Mapper.Map<StockDTO>(result);
        }

        public async Task DeleteAsync(int id)
        {
            await _stockService.DeleteAsync(id);
        }
    }
}
