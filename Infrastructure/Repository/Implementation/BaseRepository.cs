using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementation
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        protected BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> FindAsync(int id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> AddAsync(T t)
        {
            await _dataContext.Set<T>().AddAsync(t);

            return t;
        }

        #region Disposal

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;
            if (disposing)
            {
                _dataContext.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
