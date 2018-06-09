using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> FindAsync(int id);
        Task<T> InsertAsync(T t);
        Task<T> UpdateAsync(T t, object key);
        Task DeleteAsync(object key);
        Task<int> SaveAsync();
        void Dispose();
    }
}
