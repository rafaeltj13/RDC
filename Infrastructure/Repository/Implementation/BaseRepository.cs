using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementation
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DataContext _dataContext;

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

        public async Task<T> InsertAsync(T t)
        {
            await _dataContext.Set<T>().AddAsync(t);

            return t;
        }

        public async Task<T> UpdateAsync(T t, object key)
        {
            if (t == null)
                return null;

            var exist = await _dataContext.Set<T>().FindAsync(key);

            if (exist != null)
            {
                _dataContext.Entry(exist).CurrentValues.SetValues(t);
            }

            return exist;
        }

        public async Task DeleteAsync(object key)
        {
            var entity = await _dataContext.Set<T>().FindAsync(key);
            _dataContext.Set<T>().Remove(entity);
        }

        public async Task<int> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync();
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
