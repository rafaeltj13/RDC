using Entities;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUserDomainService : IBaseService<User>
    {
        Task<User> GetByLoginAsync(string login);
    }
}
