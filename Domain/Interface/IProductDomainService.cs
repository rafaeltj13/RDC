using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IProductDomainService : IBaseService<Product>
    {
        Task<ICollection<Product>> GetByFirstLetterAsync(char letter);
    }
}
