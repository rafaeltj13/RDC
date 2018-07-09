using Entities;
using Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Implementation
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        public StockRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
