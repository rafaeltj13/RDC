using Infrastructure.Repository.Interface;
using System.Threading.Tasks;

namespace Infrastructure.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }

        Task SaveAsync();
    }
}
