using Entities;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementation
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<ICollection<Product>> GetByFirstLetterAsync(char letter)
        {
            return await _dataContext.Set<Product>().FromSql("SELECT * FROM dbo.Products").Where(p => p.Name[0] == letter).ToListAsync();
        }
    }
}
