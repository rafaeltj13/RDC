using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBaseService<T>
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> FindAsync(int id);
        Task<T> AddAsync(T entity);
    }
}
