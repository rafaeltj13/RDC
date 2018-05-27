using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> FindAsync(int id);
        Task<T> AddAsync(T t);
        void Dispose();
    }
}
