using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interface
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<ICollection<Product>> GetByFirstLetterAsync(char letter);
    }
}
