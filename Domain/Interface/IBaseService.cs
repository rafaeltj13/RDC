using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBaseService<T>
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> FindAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity, object key);
        Task DeleteAsync(object key);
    }
}
