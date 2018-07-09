using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IStockAppService
    {
        Task<ICollection<StockDTO>> GetAllAsync();
        Task<StockDTO> FindAsync(int id);
        Task<StockDTO> InsertAsync(StockDTO stock);
        Task<StockDTO> UpdateAsync(int id, StockDTO stock);
        Task DeleteAsync(int id);
    }
}
