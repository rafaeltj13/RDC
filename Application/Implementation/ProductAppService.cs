using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Implementation
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductDomainService _productService;

        public ProductAppService(IProductDomainService productService)
        {
            _productService = productService;
        }

        public async Task<ICollection<ProductDTO>> GetAllAsync()
        {
            var result = await _productService.GetAllAsync();
            return AutoMapper.Mapper.Map<ICollection<ProductDTO>>(result);
        }

        public async Task<ProductDTO> FindAsync(int id)
        {
            var result = await _productService.FindAsync(id);
            return AutoMapper.Mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> InsertAsync(ProductDTO product)
        {
            var result = await _productService.InsertAsync(AutoMapper.Mapper.Map<Product>(product));
            return AutoMapper.Mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> UpdateAsync(int id, ProductDTO product)
        {
            var result = await _productService.UpdateAsync(AutoMapper.Mapper.Map<Product>(product), id);
            return AutoMapper.Mapper.Map<ProductDTO>(result);
        }

        public async Task DeleteAsync(int id)
        {
            await _productService.DeleteAsync(id);
        }
    }
}
