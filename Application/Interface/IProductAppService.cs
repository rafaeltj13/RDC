using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IProductAppService
    {
        Task<ICollection<ProductDTO>> GetAllAsync();
        Task<ProductDTO> FindAsync(int id);
        Task<ICollection<ProductDTO>>  GetByFirstLetterAsync(char letter);
        Task<ProductDTO> InsertAsync(ProductDTO product);
        Task<ProductDTO> UpdateAsync(int id, ProductDTO product);
        Task DeleteAsync(int id);
    }
}
