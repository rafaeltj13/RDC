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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            return await _dataContext.Set<User>().FromSql("SELECT * FROM dbo.Users").Where(user => user.Login == login).FirstAsync();
        }
    }
}
