using Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByLoginAsync(string login);
    }
}
